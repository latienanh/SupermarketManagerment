using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Infastructure;

namespace Supermarket.Infrastructure.Repsitories
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly SuperMarketDbContext _superMarketDbContext;
        private readonly IMapper _mapper;

        public AttributeRepository(SuperMarketDbContext superMarketDbContext,
            IMapper mapper)
        {
            _superMarketDbContext = superMarketDbContext;
            _mapper = mapper;
        }
        public async Task<ICollection<AttributeDto>> GetAllAsync()
        {
            var result = await _superMarketDbContext.Attributes.Where(x=>x.IsDelete==false).ToListAsync();
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
             var attribute = _mapper.Map<Domain.Entities.SupermarketEntities.Attribute>(entity);
                        await _superMarketDbContext.Attributes.AddAsync(attribute);
                        await _superMarketDbContext.SaveChangesAsync();
                        return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public async Task<bool> UpdateAsync(AttributeDto entity,int Id)
        {
            var attributeUpdate = await _superMarketDbContext.Attributes
                .FirstOrDefaultAsync(x => x.Id == Id && x.IsDelete == false);
               if (attributeUpdate != null)
               {
                attributeUpdate.AttributeName=entity.AttributeName;
                attributeUpdate.ModifiedTime = DateTime.UtcNow;
                attributeUpdate.ModifiedBy = 1;
                await _superMarketDbContext.SaveChangesAsync();
                return true;
               }
               return false;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var attributeUpdate = await _superMarketDbContext.Attributes
                .FirstOrDefaultAsync(x => x.Id == Id );
            if (attributeUpdate != null)
            {
                attributeUpdate.IsDelete=true;
                await _superMarketDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
