using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.Auth;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;


namespace Supermarket.Application.IRepositories;

public interface IAuthRepository
{
    Task<LoginResponseDtos> LoginAsync(LoginBasicRequestDtos loginDtos);
    Task<IdentityResult> SignUpAsync(UserRequestDto userRequestDtos);
    Task<LoginResponseDtos> RenewTokenAsync(LoginTokenRequestDtos loginTokenRequest);
}