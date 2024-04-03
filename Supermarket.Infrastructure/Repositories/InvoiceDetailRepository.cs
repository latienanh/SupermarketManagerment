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
    public class InvoiceDetailRepository: RepositoryBase<InvoiceDetail>,IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(IDbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper) { }
    }
}
