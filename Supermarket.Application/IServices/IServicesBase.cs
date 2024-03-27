namespace Supermarket.Application.IServices;

public interface IServicesBase<T>
{
    Task<ICollection<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<bool> CreateAsync(T entity);
    Task<bool> UpdateAsync(T entity, int id);
    Task<bool> DeleteAsync(int id);
}