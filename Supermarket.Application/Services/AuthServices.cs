using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.Auth;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelRequests;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Application.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IAuthRepository _authRepository;

        public AuthServices(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<LoginResponses> LoginDtos(LoginDtos loginDtos)
        {
            return await _authRepository.Login(loginDtos);
        }

        public async Task<IdentityResult>SignUp(SignUpDtos signUpDtos)
        {
            return await _authRepository.SignUp(signUpDtos);
        }
        public async Task<LoginResponses> RenewTokenAsync(LoginTokenRequest loginTokenRequest)
        {
            return await _authRepository.RenewTokenAsync(loginTokenRequest);
        }
    }
}
