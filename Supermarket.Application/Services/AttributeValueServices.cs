using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services;

public class AttributeValueServices : IAttributeValueServices
{
    private readonly IAttributeValueRepository _attributeValueRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AttributeValueServices(IAttributeValueRepository attributeValueRepository, IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _attributeValueRepository = attributeValueRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ICollection<AttributeValueDto>> GetAllAsync()
    {
        var result = await _attributeValueRepository.GetAllAsync();
        var listAttributeValue = _mapper.Map<ICollection<AttributeValueDto>>(result);
      
        return listAttributeValue;
    }

    public async Task<AttributeValueDto> GetByIdAsync(int id)
    {
        var result = await _attributeValueRepository.GetSingleByIdAsync(id);
        var attributeValue = _mapper.Map<AttributeValueDto>(result);
        return attributeValue;
    }

    public async Task<bool> CreateAsync(AttributeValueDto entity)
    {
        if (entity == null)
            return false;
        var attrbutevalue = _mapper.Map<AttributeValue>(entity);
        await _attributeValueRepository.AddAsync(attrbutevalue);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(AttributeValueDto entity, int id)
    {
        if (entity == null)
            return false;
        var attributeValue = _mapper.Map<AttributeValue>(entity);
        var entityType = "AttributeValue";
        await _attributeValueRepository.UpdateAsync(attributeValue,id,entityType);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await _attributeValueRepository.DeleteAsync(id);
        _unitOfWork.CommitAsync();
        return true;
    }
}