using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
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

    public async Task<IEnumerable<AttributeValueResponseDto>> GetAllAsync()
    {
        var result = await _attributeValueRepository.GetAllAsync();
        var listAttributeValue = _mapper.Map<ICollection<AttributeValueResponseDto>>(result);
      
        return listAttributeValue;
    }

    public async Task<AttributeValueResponseDto> GetByIdAsync(int id)
    {
        var result = await _attributeValueRepository.GetSingleByIdAsync(id);
        var attributeValue = _mapper.Map<AttributeValueResponseDto>(result);
        return attributeValue;
    }

    public async Task<bool> CreateAsync(AttributeValueRequestDto entity)
    {
        if (entity == null)
            return false;
        var attrbutevalue = _mapper.Map<VariantValue>(entity);
        await _attributeValueRepository.AddAsync(attrbutevalue);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(AttributeValueRequestDto entity, int id)
    {
        if (entity == null)
            return false;
        var attributeValue = _mapper.Map<VariantValue>(entity);
        var entityType = "AttributeValue";
        await _attributeValueRepository.UpdateAsync(attributeValue,id,entityType);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await _attributeValueRepository.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        return true;
    }
}