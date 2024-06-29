using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;


namespace Supermarket.Application.IServices;

public interface IAuthServices
{
    Task<LoginResponseDtos?> LoginAsync(LoginBasicRequestDtos loginBasicRequestDtos);
    Task<IdentityResult> SignUp(SignUpRequestDto signUpRequestDto);
    Task<LoginResponseDtos> RenewTokenAsync(LoginTokenRequestDtos loginTokenRequestDtos);
    Task<bool> LogOut(Guid id);
}