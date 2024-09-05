using AutoMapper;
using Supermarket.Infrastructure.DbFactories;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Infrastructure.Repositories
{
    public class InvoiceDetailRepository: RepositoryBase<InvoiceDetail>,IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(IDbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper) { }
    }
}
