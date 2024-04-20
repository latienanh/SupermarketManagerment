using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
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
                    foreach (var variantValue in variant.VariantValue)
                    {
                        var variantValueNew = new VariantValue();
                        variantValueNew.AttributeValueName = variantValue.VariantValue;
                        variantValueNew.AttributeId = variantValue.AttributeId;
                        variantValueNew.ProductId = parentProductId;
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
            var result = await _productRepository.UpdateAsync(entityMap, id, "Product", userID);
            if (result == null)
                return false;
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
    }
}
