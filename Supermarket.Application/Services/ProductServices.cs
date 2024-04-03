using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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


        public ProductServices(IProductRepository productRepository,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
             var result = await _productRepository.GetAllAsync(IncludeConstants.ProductIncludes);
            var resultMap = _mapper.Map<IEnumerable<ProductResponseDto>>(result);
             return resultMap;
        }

        public async Task<ProductResponseDto> GetByIdAsync(int id)
        {
            var result = await _productRepository.GetSingleByConditionAsync((product) => product.Id ==id,
                IncludeConstants.ProductIncludes);
            var resultMap = _mapper.Map<ProductResponseDto>(result);
            return resultMap;
        }

        public async Task<bool> CreateAsync(ProductRequestDto entity)
        {
            var entityMap = _mapper.Map<Product>(entity);
            var resultAddCategory = await _productRepository.AddToCategoryAsync(entityMap, entity.CategoriesId);
            var result = await _productRepository.AddAsync(entityMap);
            await _unitOfWork.CommitAsync();
            return result!=null?true:false;
        }

        public async Task<bool> UpdateAsync(ProductRequestDto entity, int id)
        {
            var entityMap = _mapper.Map<Product>(entity);
            var result = await _productRepository.UpdateAsync(entityMap,id,"Product");
            await _unitOfWork.CommitAsync();
            return result != null ? true : false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _productRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            return result!=null?true:false;
        }
    }
}
