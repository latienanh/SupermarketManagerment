using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.IRepositories;

public interface ICategoryRepository:IEntityRepository<Category>
{
    Task<Category> UpdateAsyncCategory(Category entity, Guid id, string entityType, Guid userId);
}