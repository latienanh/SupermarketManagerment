using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVariantValueRepository _variantValueRepository;


        public ProductServices(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork, IVariantValueRepository variantValueRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _variantValueRepository = variantValueRepository;
        }
        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            var result = await _productRepository.GetAllAsync(IncludeConstants.ProductIncludes);
            var resultMap = _mapper.Map<IEnumerable<ProductResponseDto>>(result);
            return resultMap;
        }

        public async Task<ProductResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _productRepository.GetSingleByConditionAsync((product) => product.Id == id,
                IncludeConstants.ProductIncludes);
            var resultMap = _mapper.Map<ProductResponseDto>(result);
            return resultMap;
        }

        public async Task<bool> CreateAsync(ProductRequestDto entity, Guid userID)
        {
            var entityMap = _mapper.Map<Product>(entity);

            entityMap.Image = entity.PathImage;

            if (!entity.CategoriesId.IsNullOrEmpty())
            {
                var resultAddCategory = await _productRepository.AddToCategoryAsync(entityMap, entity.CategoriesId);
                if (!resultAddCategory)
                    return false;
            }
            var result = await _productRepository.AddAsync(entityMap, userID);
            if (result == null)
                return false;
            if (!entity.Variants.IsNullOrEmpty())
            {
                Guid parentProductId = entityMap.Id;
                foreach (var variant in entity.Variants)
                {
                    var variantMap = _mapper.Map<Product>(variant);
                    variantMap.Image = variant.PathImage;
                    variantMap.ParentId = parentProductId;
                    if (entity.CategoriesId != null)
                    {
                        if (!entity.CategoriesId.IsNullOrEmpty())
                        {
                            await _productRepository.AddToCategoryAsync(variantMap, entity.CategoriesId);
                        }
                    }
                    var resultVatiant = await _productRepository.AddAsync(variantMap, userID);
                    if (resultVatiant == null)
                    {
                        return false;
                    }
                    foreach (var variantValue in variant.VariantValues)
                    {
                        var variantValueNew = new VariantValue();
                        variantValueNew.AttributeValueName = variantValue.VariantValue;
                        variantValueNew.AttributeId = variantValue.AttributeId;
                        variantValueNew.ProductId = variantMap.Id;
                        var resultVariantValue = await _variantValueRepository.AddAsync(variantValueNew, userID);
                        if (resultVariantValue == null)
                            return false;
                    }
                }
            }
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(ProductRequestDto entity, Guid id, Guid userID)
        {
            var entityMap = _mapper.Map<Product>(entity);
            if (entity.PathImage != null)
            {
                entityMap.Image = entity.PathImage;
            }
            var result = await _productRepository.UpdateAsyncProduct(entityMap, id, "Product", userID);
            if (result == null)
                return false;
            if (!entity.CategoriesId.IsNullOrEmpty())
            {
                var resultUpdateCategory = await _productRepository.UpdateToCategoryAsync(result, entity.CategoriesId);
                if (!resultUpdateCategory)
                    return false;
            }
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, Guid userID)
        {
            var result = await _productRepository.DeleteAsync(id, userID);
            if (result == null)
                return false;
            await _unitOfWork.CommitAsync();
            return true;
        }
        public async Task<IEnumerable<ProductsPagingResponseDto>> getPagingAsync(int index, int size)
        {
            var result = await _productRepository.GetMultiPagingAsync(x => x.IsDelete == false && x.ParentId == null, index, size, IncludeConstants.ProductIncludes);
            var resultChildren = await _productRepository.GetMultiAsync(x => x.IsDelete == false && x.ParentId != null, IncludeConstants.ProductIncludes);
            var resultMap = _mapper.Map<IEnumerable<ProductsPagingResponseDto>>(result);
            foreach (var productParent in resultMap)
            {
                var children = resultChildren.Where(x => x.ParentId == productParent.id);
                if (children.Any())
                {
                    productParent.Variants = _mapper.Map<IEnumerable<ProductResponseDto>>(children);
                }
            }
            return resultMap;
        }

        public async Task<int> getTotalPagingTask(int size)
        {
            var result = await _productRepository.CountAsync(x => x.IsDelete == false && x.ParentId == null);
            decimal total = Math.Ceiling((decimal)result / size);
            return (int)total;
        }
    }
}
