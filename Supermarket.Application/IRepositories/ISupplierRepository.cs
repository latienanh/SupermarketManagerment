using Supermarket.Domain.Entities.SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.IRepositories
{
    public interface ISupplierRepository : IEntityRepository<Supplier>
    {
    }
}
