namespace Supermarket.Application.IRepositories
{
    public interface IBasicRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity, Guid id);
        Task<T> DeleteAsync(Guid id);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
