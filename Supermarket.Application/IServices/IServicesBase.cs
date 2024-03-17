using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.IServices
{
    public interface IServicesBase<T>
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int Id);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity,int Id);
        Task<bool> DeleteAsync(int Id);
    }
}
