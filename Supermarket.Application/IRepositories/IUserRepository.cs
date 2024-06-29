namespace Supermarket.Application.IRepositories
{
    public interface IUserRepository<TRequest,TUpdateRequest, TResponse>
    {
        Task<TResponse> AddAsync(TRequest entity);
        Task<TResponse> UpdateAsync(TUpdateRequest entity, Guid id);
        Task<TResponse> DeleteAsync(Guid id);
        Task<TResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<TResponse>> GetAll();
    }
}
