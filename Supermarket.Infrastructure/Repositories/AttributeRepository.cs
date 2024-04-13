using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.Common;
using Supermarket.Infrastructure.DbFactories;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Infrastructure.Repositories;

public class AttributeRepository : RepositoryBase<Attribute>,IAttributeRepository
{
    public AttributeRepository(IDbFactory dbFactory,IMapper mapper) : base(dbFactory,mapper)
    {
    }
       
}