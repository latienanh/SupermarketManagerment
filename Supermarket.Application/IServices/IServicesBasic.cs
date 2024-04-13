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
        Task<TReponseDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(TRequestDto entity);
        Task<bool> UpdateAsync(TRequestDto entity, int id);
        Task<bool> DeleteAsync(int id);
    }
}
