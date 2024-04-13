using AutoMapper;
using Supermarket.Infrastructure.DbFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Infrastructure.Repositories
{
    public class MemberShipTypeRepository : RepositoryBase<MemberShipType>,IMemberShipTypeRepository

    {
    public MemberShipTypeRepository(IDbFactory dbFactory, IMapper mapper, int userId) : base(dbFactory, mapper, userId)
    {
    }
    }
}
