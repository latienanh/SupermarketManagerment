using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.IServices
{
    public interface ICustomerServices: IServicesBase<CustomerRequestDto,CustomerResponseDto>,IGetPaging<CustomerResponseDto>
    {
    }
}
