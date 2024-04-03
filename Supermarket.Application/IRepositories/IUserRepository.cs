using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.IRepositories
{
    public interface IUserRepository<TRequest, TResponse>
    {
        Task<TResponse> AddAsync(TRequest entity);
        Task<TResponse> UpdateAsync(TRequest entity, int id);
        Task<TResponse> DeleteAsync(int id);
        Task<TResponse> GetByIdAsync(int id);
        Task<IEnumerable<TResponse>> GetAll();
    }
}
