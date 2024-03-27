using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.Common;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Infrastructure.Repositories;

public class AttributeRepository : IAttributeRepository
{
    private readonly IMapper _mapper;
    private readonly SuperMarketDbContext _superMarketDbContext;

    public AttributeRepository(SuperMarketDbContext superMarketDbContext,
        IMapper mapper)
    {
        _superMarketDbContext = superMarketDbContext;
        _mapper = mapper;
    }

    public async Task<ICollection<AttributeDto>> GetAllAsync()
    {
        var result = await _superMarketDbContext.Attributes.Where(x => x.IsDelete == false).ToListAsync();
        var mapperResult = _mapper.Map<List<AttributeDto>>(result);
        return mapperResult;
    }

    public async Task<AttributeDto> GetByIdAsync(int id)
    {
        var result =
            await _superMarketDbContext.Attributes.FirstOrDefaultAsync(x => x.Id == id && x.IsDelete == false);
        var mapperResult = _mapper.Map<AttributeDto>(result);
        return mapperResult;
    }

    public async Task<bool> CreateAsync(AttributeDto entity)
    {
        try
        {
            var attribute = _mapper.Map<Attribute>(entity);
            await _superMarketDbContext.Attributes.AddAsync(attribute);
            await _superMarketDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(AttributeDto entity, int Id)
    {
        var attributeUpdate = await _superMarketDbContext.Attributes
            .FirstOrDefaultAsync(x => x.Id == Id && x.IsDelete == false);

        if (attributeUpdate != null)
        {
            attributeUpdate.AttributeName = entity.AttributeName;
            var updateModifed = new ModificationDto
            {
                ModifiedBy = null,
                ModifiedTime = DateTime.UtcNow,
                EntityId = attributeUpdate.Id,
                EntityType = "Attribute"
            };
            var mapperUpdateM = _mapper.Map<Modification>(updateModifed);
            _superMarketDbContext.Modifications.Add(mapperUpdateM);
            await _superMarketDbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteAsync(int Id)
    {
        var attributeUpdate = await _superMarketDbContext.Attributes
            .FirstOrDefaultAsync(x => x.Id == Id);
        if (attributeUpdate != null)
        {
            attributeUpdate.IsDelete = true;
            await _superMarketDbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}