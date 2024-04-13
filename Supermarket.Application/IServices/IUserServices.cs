using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;

namespace Supermarket.Application.IServices
{
    public interface IUserServices: IServicesBasic<UserRequestDto,UserResponseDto>
    {
        Task<bool> GetLoggedInUserId ();
    }
}
