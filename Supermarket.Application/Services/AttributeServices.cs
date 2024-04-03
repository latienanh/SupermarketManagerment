using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.SupermarketEntities;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Application.Services;

public class AttributeServices : IAttributeServices
{
    private readonly IAttributeRepository _attributeRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AttributeServices(IAttributeRepository attributeRepository, IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _attributeRepository = attributeRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AttributeResponseDto>> GetAllAsync()
    {
        var result = await _attributeRepository.GetAllAsync();
        var listAttribute = _mapper.Map<ICollection<AttributeResponseDto>>(result);
        return listAttribute;
    }

    public async Task<AttributeResponseDto> GetByIdAsync(int id)
    {
        var result = await _attributeRepository.GetSingleByIdAsync(id);
        var attribute = _mapper.Map<AttributeResponseDto>(result);
        return attribute;
    }

    public async Task<bool> CreateAsync(AttributeRequestDto entity)
    {
        if (entity == null)
            return false;
        var attrbute = _mapper.Map<Attribute>(entity);
        await _attributeRepository.AddAsync(attrbute);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(AttributeRequestDto entity, int id)
    {
        if (entity == null)
            return false;
        var attributeValue = _mapper.Map<Attribute>(entity);
        var entityType = "Attribute";
        await _attributeRepository.UpdateAsync(attributeValue, id, entityType);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await _attributeRepository.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        return true;
    }
}