using AutoMapper;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories
{
    public class BatchRepository: RepositoryBase<Batch>,IBatchRepository
    {
        public BatchRepository(IDbFactory dbFactory,IMapper mapper): base(dbFactory,mapper) { }
    }
}
