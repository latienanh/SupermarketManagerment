using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services.Product.Commands.CreateProduct
{
    public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand,Guid?>
    {
        private readonly IProductRepository _productRepository;
        private readonly IVariantValueRepository _variantValueRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository,IVariantValueRepository variantValueRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _productRepository = productRepository;
            _variantValueRepository = variantValueRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid?> Handle(CreateProductCommand createProductCommand, CancellationToken cancellationToken)
        {
            var entityMap = _mapper.Map<Domain.Entities.SupermarketEntities.Product>(createProductCommand.product);

            entityMap.Image = createProductCommand.product.PathImage;

            if (!createProductCommand.product.CategoriesId.IsNullOrEmpty())
            {
                var resultAddCategory = await _productRepository.AddToCategoryAsync(entityMap, createProductCommand.product.CategoriesId);
                if (!resultAddCategory)
                    return null;
            }
            var result = await _productRepository.AddAsync(entityMap, createProductCommand.userId);
            if (result == null)
                return null;
            if (!createProductCommand.product.Variants.IsNullOrEmpty())
            {
                Guid parentProductId = entityMap.Id;
                foreach (var variant in createProductCommand.product.Variants)
                {
                    var variantMap = _mapper.Map<Domain.Entities.SupermarketEntities.Product>(variant);
                    variantMap.Image = variant.PathImage;
                    variantMap.ParentId = parentProductId;
                    if (createProductCommand.product.CategoriesId != null)
                    {
                        if (!createProductCommand.product.CategoriesId.IsNullOrEmpty())
                        {
                            await _productRepository.AddToCategoryAsync(variantMap, createProductCommand.product.CategoriesId);
                        }
                    }
                    var resultVatiant = await _productRepository.AddAsync(variantMap, createProductCommand.userId);
                    if (resultVatiant == null)
                    {
                        return null;
                    }
                    foreach (var variantValue in variant.VariantValues)
                    {
                        var variantValueNew = new VariantValue();
                        variantValueNew.AttributeValueName = variantValue.VariantValue;
                        variantValueNew.AttributeId = variantValue.AttributeId;
                        variantValueNew.ProductId = variantMap.Id;
                        var resultVariantValue = await _variantValueRepository.AddAsync(variantValueNew, createProductCommand.userId);
                        if (resultVariantValue == null)
                            return null;
                    }
                }
            }
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
            //var product = _mapper.Map<Domain.Entities.SupermarketEntities.Product>(request.product);
            //var result =await _productRepository.AddAsync(product,request.userId);
            //await _unitOfWork.CommitAsync(cancellationToken);
            //return result.Id;
        }


        
    }
}
