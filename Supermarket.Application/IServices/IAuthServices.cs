using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.Auth;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;


namespace Supermarket.Application.IServices;

public interface IAuthServices
{
    Task<LoginResponseDtos> LoginAsync(LoginBasicRequestDtos loginBasicRequestDtos);
    Task<IdentityResult> SignUp(UserRequestDto userRequestDtos);
    Task<LoginResponseDtos> RenewTokenAsync(LoginTokenRequestDtos loginTokenRequestDtos);
}