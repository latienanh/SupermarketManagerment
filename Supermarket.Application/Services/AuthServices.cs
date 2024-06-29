using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;

using Supermarket.Application.UnitOfWork;

namespace Supermarket.Application.Services;

public class AuthServices : IAuthServices
{
    private readonly IAuthRepository _authRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AuthServices(IAuthRepository authRepository, IUnitOfWork unitOfWork)
    {
        _authRepository = authRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<LoginResponseDtos?> LoginAsync(LoginBasicRequestDtos loginBasicRequestDtos)
    {
        var result = await _authRepository.LoginAsync(loginBasicRequestDtos);
        await _unitOfWork.CommitAsync();
        return result;
    }

    public async Task<IdentityResult> SignUp(SignUpRequestDto signUpRequestDto)
    {
        var result = await _authRepository.SignUpAsync(signUpRequestDto);
        await _unitOfWork.CommitAsync();
        return result;
    }

  
    public async Task<LoginResponseDtos> RenewTokenAsync(LoginTokenRequestDtos loginTokenRequestDtos)
    {
        var result = await _authRepository.RenewTokenAsync(loginTokenRequestDtos);
        await _unitOfWork.CommitAsync();
        return result;
    }

    public async Task<bool> LogOut(Guid id)
    {
        var result = await _authRepository.LogOut(id);
        await _unitOfWork.CommitAsync();
        return result;
    }
}