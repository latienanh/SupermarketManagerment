using AutoMapper;
using Supermarket.Infrastructure.DbFactories;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Infrastructure.Repositories
{
    public class InvoiceRepository : RepositoryBase<Invoice>,IInvoiceRepository
    {
        public InvoiceRepository(IDbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper) { }
    }
}
