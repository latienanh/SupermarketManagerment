using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Domain.Abstractions.IRepositories
{
    public interface IUserRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity, Guid id);
        Task<T> DeleteAsync(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Task<bool> AddRoleInUser(IEnumerable<Guid> Roles, T entity);
        Task<bool> UpdateRoleInUser(IEnumerable<Guid> Roles, T entity);
        Task<IEnumerable<T>> GetAll();
    }
}
