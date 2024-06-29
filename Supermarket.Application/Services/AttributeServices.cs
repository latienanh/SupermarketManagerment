using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
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

    public async Task<AttributeResponseDto> GetByIdAsync(Guid id)
    {
        var result = await _attributeRepository.GetSingleByIdAsync(id);
        var attribute = _mapper.Map<AttributeResponseDto>(result);
        return attribute;
    }

    public async Task<bool> CreateAsync(AttributeRequestDto entity, Guid userID)
    {
        if (entity == null)
            return false;
        var attrbute = _mapper.Map<Attribute>(entity);
        var result = await _attributeRepository.AddAsync(attrbute, userID);
        if (result == null)
            return false;
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(AttributeRequestDto entity, Guid id, Guid userID)
    {
        if (entity == null)
            return false;
        var attributeValue = _mapper.Map<Attribute>(entity);
        var entityType = "Attribute";
        var result = await _attributeRepository.UpdateAsync(attributeValue, id, entityType, userID);
        if (result == null)
            return false;
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, Guid userID)
    {
        var result = await _attributeRepository.DeleteAsync(id, userID);
        if (result == null)
            return false;
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<IEnumerable<AttributeResponseDto>> getPagingAsync(int index, int size)
    {
        var result = await _attributeRepository.GetMultiPagingAsync(x => x.IsDelete == false , index, size);
        var resultMap = _mapper.Map<IEnumerable<AttributeResponseDto>>(result);
        return resultMap;
    }

    public async Task<int> getTotalPagingTask(int size)
    {
        var result = await _attributeRepository.CountAsync(x => x.IsDelete == false);
        decimal total = Math.Ceiling((decimal)result / size);
        return (int)total;
    }
    

 
}