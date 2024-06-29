using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;

namespace Supermarket.Application.IServices
{
    public interface IUserServices: IServicesBasic<UserRequestDto,UserUpdateRequestDto,UserResponseDto>
    {
    }
}
