using Supermarket.Domain.Entities.SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.IRepositories
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        Task<bool> AddToCategoryAsync(Product product,IEnumerable<int> categoryIds);
    }
}
