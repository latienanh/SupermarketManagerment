using AutoMapper;
using Supermarket.Application.IRepositories;
using Supermarket.Infrastructure.DbFactories;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Infrastructure.Repositories;

public class AttributeRepository : RepositoryBase<Attribute>,IAttributeRepository
{
    public AttributeRepository(IDbFactory dbFactory,IMapper mapper) : base(dbFactory,mapper)
    {
    }
       
}