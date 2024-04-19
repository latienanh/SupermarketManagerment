using AutoMapper;
using Supermarket.Infrastructure.DbFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository;
        public ProductRepository(ICategoryRepository categoryRepository,IDbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> AddToCategoryAsync(Product product, IEnumerable<Guid> categoryIds)
        {
           
            if (product == null)
            {
                return false; 
            }
            foreach (var categoryId in categoryIds)
            {
                var category = await _categoryRepository.GetSingleByIdAsync(categoryId);
                if (category != null)
                {
                    product.Categories.Add(category);
                }
            }
            return true;
        }


      
    }
}
