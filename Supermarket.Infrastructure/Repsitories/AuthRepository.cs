using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.Auth;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Infrastructure.Settings;

namespace Supermarket.Infrastructure.Repsitories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JsonWebTokenSettings _jsonWebTokenSettings;
        private readonly IMapper _mapper;
        public AuthRepository(
            UserManager<AppUser> userManager ,
            SignInManager<AppUser> signInManager,
            JsonWebTokenSettings jsonWebTokenSettings,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jsonWebTokenSettings = jsonWebTokenSettings;
            _mapper = mapper;
        }
        public async Task<string> Login(LoginDtos loginDtos)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDtos.UserName,
                 loginDtos.Password, false, false);
            if (!result.Succeeded)
            {
                return result.Succeeded.ToString();
            }

            var authClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,loginDtos.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jsonWebTokenSettings.SecretKey)); 
            var token = new JwtSecurityToken(
                issuer: _jsonWebTokenSettings.ValidIssuer,
                audience: _jsonWebTokenSettings.ValidAudience,
                expires: DateTime.Now.AddMinutes(10),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256)
            );  
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUp(SignUpDtos signUpDtos)
        {
            var user = _mapper.Map<AppUser>(signUpDtos);
            return await _userManager.CreateAsync(user,signUpDtos.Password);
        }
    }
}
