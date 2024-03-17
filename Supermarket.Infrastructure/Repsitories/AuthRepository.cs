using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.Auth;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelRequests;
using Supermarket.Application.ModelResponses;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Domain.Entities.Token;
using Supermarket.Infastructure;
using Supermarket.Infrastructure.Settings;

namespace Supermarket.Infrastructure.Repsitories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JsonWebTokenSettings _jsonWebTokenSettings;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly SuperMarketDbContext _supermarketDbContext;
        private readonly ITokenServices _TokenServices;
        private readonly IMapper _mapper;
        public AuthRepository(
            UserManager<AppUser> userManager ,
            SignInManager<AppUser> signInManager,
            JsonWebTokenSettings jsonWebTokenSettings,
            RoleManager<IdentityRole<int>> roleManager,
            SuperMarketDbContext supermarketDbContext,
            ITokenServices TokenServices,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jsonWebTokenSettings = jsonWebTokenSettings;
            _roleManager = roleManager;
            _supermarketDbContext = supermarketDbContext;
            _TokenServices = TokenServices;
            _mapper = mapper;
            
        }
        public async Task<LoginResponses> Login(LoginDtos loginDtos)
        {
            var user = await _userManager.FindByNameAsync(loginDtos.UserName);
            var passwordValid = await _userManager.CheckPasswordAsync(user, loginDtos.Password);
            if (user==null||!passwordValid)
            {
                return new LoginResponses()
                {
                    AccessToken = string.Empty,
                  
                };
            }
            var token = await _TokenServices.GenerateAccessTokenAsync(user);

            var RefreshToken = new RefreshToken()
                {
                    Token = await _TokenServices.GenerateRefreshTokenAsync(),
                    Expriaton = DateTime.UtcNow.AddMinutes(2),
                    UserId = user.Id
                };
            var refeshToken = await _supermarketDbContext.RefreshTokens.FirstOrDefaultAsync(u => u.UserId == user.Id);
            if (refeshToken == null)
            {
                
                await _TokenServices.CreateRefreshTokenAsync(RefreshToken); 
                return new LoginResponses()
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationAT = token.ValidTo,
                    RefreshToken = RefreshToken.Token,
                    ExpirationRT = RefreshToken.Expriaton
                };
            }
            else
            {                
                if(refeshToken.Expriaton<DateTime.UtcNow)
                await _TokenServices.UpdateRefreshTokenAsync(RefreshToken);
                return new LoginResponses()
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationAT = token.ValidTo,
                    RefreshToken = refeshToken.Token,
                    ExpirationRT = refeshToken.Expriaton
                };
            }
           
        }

        public async Task<IdentityResult> SignUp(SignUpDtos signUpDtos)
        {
            var user = _mapper.Map<AppUser>(signUpDtos);
            var result = await _userManager.CreateAsync(user, signUpDtos.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(AppRole.Salesperson))
                {
                    await _roleManager.CreateAsync(new IdentityRole<int>(AppRole.Salesperson));
                }

                await _userManager.AddToRoleAsync(user, AppRole.Salesperson);
            }
            return result; 
        }

        public async Task<LoginResponses> RenewTokenAsync(LoginTokenRequest loginTokenRequest)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_jsonWebTokenSettings.SecretKey);
            var param = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _jsonWebTokenSettings.ValidIssuer,
                ValidAudience = _jsonWebTokenSettings.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                ClockSkew = new TimeSpan(0, 0, 5),
                ValidateLifetime = false
            };
            try
            {
                //check 1 :AccessToken Validate 
                var tokenInVerification = jwtTokenHandler.ValidateToken(loginTokenRequest.AccessToken, param,out var validatedToken);
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    //check 2 : kiem tra ma hoa
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase);
                    if (!result)
                    {
                        return null;
                    }
                  
                }
                //check 3 : check han accesstoken
                var utcExpireDate = long.Parse(tokenInVerification.Claims
                    .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
                var expriceDate = ConvertUtcTime(utcExpireDate);
            
                
                if (expriceDate > DateTime.UtcNow)
                {
                    return null;
                }
                else
                {
                    //check 4 : Refesh co ton tai khong
                 var storeRefeshToken =
                     _supermarketDbContext.RefreshTokens.FirstOrDefault(x => x.Token == loginTokenRequest.RefreshToken);
                 if (storeRefeshToken is null )
                 {
                     return null;
                 }
                 else
                 {
                     if (storeRefeshToken.Expriaton < DateTime.UtcNow)
                         return null;
                     var user = await _supermarketDbContext.Users.FirstOrDefaultAsync(x => x.Id == storeRefeshToken.UserId);
                     var token = await _TokenServices.GenerateAccessTokenAsync(user);
                     var AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
                     return new LoginResponses()
                     {
                         AccessToken = AccessToken,
                         ExpirationAT = token.ValidTo,
                         RefreshToken = storeRefeshToken.Token,
                         ExpirationRT = storeRefeshToken.Expriaton
                     };
                    }
                }
                 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public DateTime ConvertUtcTime(long utcTime)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval=dateTimeInterval.AddSeconds(utcTime).ToUniversalTime();
            return dateTimeInterval;
        }

    }
}
