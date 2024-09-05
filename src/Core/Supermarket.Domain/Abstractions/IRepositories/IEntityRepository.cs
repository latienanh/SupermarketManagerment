using System.Linq.Expressions;
using Supermarket.Domain.Primitives;

namespace Supermarket.Domain.Abstractions.IRepositories;

public interface IEntityRepository<T> where T : Entity
{
    // Marks an entity as new
    Task<T> AddAsync(T entity, Guid userId);

    // Marks an entity as modified
    Task<T> UpdateAsync(T entity,string entityType, Guid userId);

    // Marks an entity to be removed
    Task<T> DeleteAsync(T entity);

    Task<T> DeleteAsync(Guid id, Guid userId);

    //Delete multi records
    Task<bool> DeleteMultiAsync(Expression<Func<T, bool>> where);

    // Get an entity by int id
    Task<T?> GetSingleByIdAsync(Guid? id);

    Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression, string[] includes = null);

    Task<IEnumerable<T>> GetAllAsync(string[] includes = null);

    Task<IEnumerable<T>> GetMultiAsync(Expression<Func<T, bool>> predicate, string[] includes = null);

    Task<IEnumerable<T>> GetMultiPagingAsync(Expression<Func<T, bool>> predicate, int index = 0,
        int size = 50,
        string[] includes = null);

    Task<int> CountAsync(Expression<Func<T, bool>> where);

    Task<bool> CheckContainsAsync(Expression<Func<T, bool>> predicate);
}