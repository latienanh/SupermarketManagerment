using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.IServices
{
    public interface IEmployeeServices:IServicesBase<EmployeeRequestDto,EmployeeResponseDto>,IGetPaging<EmployeeResponseDto>
    {
    }
}
