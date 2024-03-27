namespace Supermarket.Application.IRepositories;

public interface IRepositoryBase<T>
{
    Task<ICollection<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<bool> CreateAsync(T entity);
    Task<bool> UpdateAsync(T entity, int Id);
    Task<bool> DeleteAsync(int Id);
}