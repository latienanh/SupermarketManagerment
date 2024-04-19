using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.IServices
{
    public interface IServicesBasic<TRequestDto, TReponseDto>
    {
        Task<IEnumerable<TReponseDto>> GetAllAsync();
        Task<TReponseDto> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(TRequestDto entity);
        Task<bool> UpdateAsync(TRequestDto entity, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
