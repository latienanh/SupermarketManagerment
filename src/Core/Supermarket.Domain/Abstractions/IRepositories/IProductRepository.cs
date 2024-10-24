﻿using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Domain.Abstractions.IRepositories
{
    public enum QuantityUpdateType
    {
        ADD = 0,
        REMOVE = 1
    }
    public interface IProductRepository : IEntityRepository<Product>
    {
        Task<bool> AddToCategoryAsync(Product product, ICollection<Guid> categoryIds);
        Task<bool> UpdateToCategoryAsync(Product product, ICollection<Guid> categoryIds);
        Task<Product> UpdateAsyncProduct(Product entity, string entityType, Guid userId);
        Task<Product> UpdateQuantityAsyncProduct(int? quantity, Guid? id, Guid userId,QuantityUpdateType type);
    }
}
