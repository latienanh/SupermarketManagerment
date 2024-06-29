using AutoMapper;
using Supermarket.Infrastructure.DbFactories;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Infrastructure.Repositories
{
    public class StockInRepository: RepositoryBase<StockIn>,IStockInRepository
    {
        public StockInRepository(IDbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper) { }
    }
}
