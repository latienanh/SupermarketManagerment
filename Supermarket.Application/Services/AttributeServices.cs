using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;

namespace Supermarket.Application.Services;

public class AttributeServices : IAttributeServices
{
    private readonly IAttributeRepository _atributeRepository;

    public AttributeServices(IAttributeRepository atributeRepository)
    {
        _atributeRepository = atributeRepository;
    }

    public async Task<ICollection<AttributeDto>> GetAllAsync()
    {
        return await _atributeRepository.GetAllAsync();
    }

    public async Task<AttributeDto> GetByIdAsync(int id)
    {
        return await _atributeRepository.GetByIdAsync(id);
    }

    public async Task<bool> CreateAsync(AttributeDto entity)
    {
        return await _atributeRepository.CreateAsync(entity);
    }

    public async Task<bool> UpdateAsync(AttributeDto entity, int Id)
    {
        return await _atributeRepository.UpdateAsync(entity, Id);
    }

    public async Task<bool> DeleteAsync(int Id)
    {
        return await _atributeRepository.DeleteAsync(Id);
    }
}