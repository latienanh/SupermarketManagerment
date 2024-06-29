using AutoMapper;
using Supermarket.Infrastructure.DbFactories;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Infrastructure.Repositories
{
    public class StockInDetailRepository: RepositoryBase<StockInDetail>,IStockInDetailRepository
    {
        public StockInDetailRepository(IDbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper) { }
    }
}
