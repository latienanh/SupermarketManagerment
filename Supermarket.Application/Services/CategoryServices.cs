using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.SupermarketEntities;
using System;

namespace Supermarket.Application.Services;

public class CategoryServices : ICategoryServices
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryServices(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _categoryRepository= categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync()
    {
        var result = await _categoryRepository.GetAllAsync();
        var resultMap = _mapper.Map<ICollection<CategoryResponseDto>>(result);
        return resultMap;
    }

    public async Task<CategoryResponseDto> GetByIdAsync(Guid id)
    {
        var result = await _categoryRepository.GetSingleByIdAsync(id);
        var resultMap= _mapper.Map<CategoryResponseDto>(result);
        return resultMap;
    }

    public async Task<bool> CreateAsync(CategoryRequestDto entity, Guid userID)
    {
        if (entity == null)
            return false;
        var attrbute = _mapper.Map<Category>(entity);
        var result=await _categoryRepository.AddAsync(attrbute, userID);
        if (result == null)
            return false;
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(CategoryRequestDto entity, Guid id, Guid userID)
    {
        if (entity == null)
            return false;
        var attributeValue = _mapper.Map<Category>(entity);
        var entityType = "Attribute";
        var result = await _categoryRepository.UpdateAsync(attributeValue, id, entityType, userID);
        if (result == null)
            return false;
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, Guid userID)
    {
        var result = await _categoryRepository.DeleteAsync(id, userID);
        if (result == null)
            return false;
        await _unitOfWork.CommitAsync();
        return true;
    }
}