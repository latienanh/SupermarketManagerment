using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Microsoft.IdentityModel.Tokens;

namespace Supermarket.Application.Services.Product.Commands.UpdateProduct
{
    public sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Guid?>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid?> Handle(UpdateProductCommand updateProductCommand, CancellationToken cancellationToken)
        {
            var entityMap =
                _mapper.Map<Domain.Entities.SupermarketEntities.Product>(updateProductCommand.UpdateProductRequest);
            if (updateProductCommand.UpdateProductRequest.PathImage != null)
            {
                entityMap.Image = updateProductCommand.UpdateProductRequest.PathImage;
            }

            var result = await _productRepository.UpdateAsyncProduct(entityMap, "Product", updateProductCommand.userId);
            if (result == null)
                return null;
            if (!updateProductCommand.UpdateProductRequest.CategoriesId.IsNullOrEmpty())
            {
                var resultUpdateCategory = await _productRepository.UpdateToCategoryAsync(result,
                    updateProductCommand.UpdateProductRequest.CategoriesId);
                if (!resultUpdateCategory)
                    return null;
            }

            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }

    }
}
