﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.Auth;
using Supermarket.Application.ModelRequests;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Application.IServices
{
    public interface IAuthServices
    {
        Task<LoginResponses>LoginDtos(LoginDtos loginDtos);
        Task<IdentityResult> SignUp(SignUpDtos signUpDtos);
        Task<LoginResponses> RenewTokenAsync(LoginTokenRequest loginTokenRequest);
    }
}
