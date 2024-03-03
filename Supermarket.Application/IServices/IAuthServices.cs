using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.Auth;

namespace Supermarket.Application.IServices
{
    public interface IAuthServices
    {
        public Task<string>  LoginDtos(LoginDtos loginDtos);
        public Task<IdentityResult> SignUp(SignUpDtos signUpDtos);
    }
}
