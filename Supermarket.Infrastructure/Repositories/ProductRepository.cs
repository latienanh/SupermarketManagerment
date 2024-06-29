using AutoMapper;
using Supermarket.Application;
using Supermarket.Infrastructure.DbFactories;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;
using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Supermarket.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository;
        private SuperMarketDbContext _dataContext;
        protected IDbFactory DbFactory { get; }
        protected SuperMarketDbContext DbContext => _dataContext ?? (_dataContext = DbFactory.Init());
        public ProductRepository(ICategoryRepository categoryRepository, IDbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
        {
            _categoryRepository = categoryRepository;
            DbFactory = dbFactory;
        }
        public async Task<bool> AddToCategoryAsync(Product product, ICollection<Guid> categoryIds)
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

        public async Task<bool> UpdateToCategoryAsync(Product product, ICollection<Guid> categoryIds)
        {
            if (product == null)
            {
                return false;
            }
            var productDB = await GetSingleByConditionAsync((p) => p.IsDelete == false && p.Id == product.Id, IncludeConstants.ProductIncludes);
            foreach (var category in productDB.Categories) // Create a copy to avoid modification issues
            {
                if (!categoryIds.Contains(category.Id)) // Check if category should be removed
                {
                    productDB.Categories.Remove(category);
                }
            }

            foreach (var categoryId in categoryIds)
            {
                if (!productDB.Categories.Any(c => c.Id == categoryId)) // Check if category already exists
                {
                    var categoryToAdd = await _categoryRepository.GetSingleByIdAsync(categoryId);
                    if (categoryToAdd != null)
                    {
                        productDB.Categories.Add(categoryToAdd);
                    }
                }
            }
            return true;
        }
        public async Task<Product> UpdateAsyncProduct(Product entity, Guid id, string entityType, Guid userId)
        {
            var entityResult = await DbContext.Products.FirstOrDefaultAsync(x => x.Id == id && x.IsDelete == false);
            if (entityResult == null)
                return null;
            entityResult.Name = entity.Name;
            entityResult.Describe = entity.Describe;
            entityResult.BarCode = entity.BarCode;
            entityResult.Slug = entity.Slug;
            entityResult.Price = entity.Price;
            if (entity.Quantity != null)
            {
                entityResult.Quantity = entity.Quantity;
            }
            if (entity.Image != null)
            {
                entityResult.Image = entity.Image;
            }
            var updateModifed = new Modification()
            {
                ModifiedBy = userId,
                ModifiedTime = DateTime.UtcNow,
                EntityId = entityResult.Id,
                EntityType = entityType
            };
            DbContext.Modifications.Add(updateModifed);
            return entityResult;
        }

        public async Task<Product> UpdateQuantityAsyncProduct(int? quantity, Guid? id, Guid userId, QuantityUpdateType type)
        {
            var entityResult = await DbContext.Products.FirstOrDefaultAsync(x => x.Id == id && x.IsDelete == false);
            if (entityResult == null)
                return null;
            // 0 mua hàng
            // 1 bán hàng
            switch (type)
            {
                case QuantityUpdateType.ADD:
                    entityResult.Quantity += quantity;
                    break;
                case QuantityUpdateType.REMOVE:
                    entityResult.Quantity -= quantity;
                    break;
            }
            return entityResult;
        }
    }
}
