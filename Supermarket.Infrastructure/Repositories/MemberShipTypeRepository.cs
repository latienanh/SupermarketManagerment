using AutoMapper;
using Supermarket.Infrastructure.DbFactories;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Infrastructure.Repositories
{
    public class MemberShipTypeRepository : RepositoryBase<MemberShipType>,IMemberShipTypeRepository

    {
    public MemberShipTypeRepository(IDbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
    {
    }
    }
}
