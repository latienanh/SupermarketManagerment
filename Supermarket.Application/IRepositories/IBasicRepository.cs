using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.IRepositories
{
    public interface IBasicRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity, int id);
        Task<T> DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
