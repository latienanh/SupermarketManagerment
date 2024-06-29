using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;


namespace Supermarket.Application.IRepositories;

public interface IAuthRepository
{
    Task<LoginResponseDtos?> LoginAsync(LoginBasicRequestDtos loginDtos);
    Task<IdentityResult> SignUpAsync(SignUpRequestDto signUpRequestDto);
    Task<LoginResponseDtos> RenewTokenAsync(LoginTokenRequestDtos loginTokenRequest);
    Task<bool> LogOut(Guid id);
}