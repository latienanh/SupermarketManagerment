using Microsoft.AspNetCore.Identity;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Domain.Abstractions.IRepositories
{
    public interface IUserRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Task<List<IdentityRole<Guid>>> GetRolesByUserAsync(T user);
        Task<bool> AddRoleInUser(IEnumerable<Guid> Roles, T entity);
        Task<bool> UpdateRoleInUser(IEnumerable<Guid> Roles, T entity);
        Task<IEnumerable<T>> GetMultiPagingAsync(int size, int index);
        Task<int> GetTotalPagingAsync(int size);
        Task<IEnumerable<T>> GetAll();
    }
}
