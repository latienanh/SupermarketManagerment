using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Domain.Entities.Token;
using Supermarket.Infrastructure.Settings;

namespace Supermarket.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly JsonWebTokenSettings _jsonWebTokenSettings;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly SuperMarketDbContext _supermarketDbContext;
    private readonly ITokenServices _tokenServices;
    private readonly UserManager<AppUser> _userManager;

    public AuthRepository(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        JsonWebTokenSettings jsonWebTokenSettings,
        RoleManager<IdentityRole<int>> roleManager,
        SuperMarketDbContext supermarketDbContext,
        ITokenServices tokenServices,
        IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jsonWebTokenSettings = jsonWebTokenSettings;
        _roleManager = roleManager;
        _supermarketDbContext = supermarketDbContext;
        _tokenServices = tokenServices;
        _mapper = mapper;
    }

    public async Task<LoginResponseDtos> LoginAsync(LoginBasicRequestDtos loginBasicRequestDtos)
    {
        var user = await _userManager.FindByNameAsync(loginBasicRequestDtos.UserName);
        var passwordValid = await _userManager.CheckPasswordAsync(user,loginBasicRequestDtos.Password);
        if (user == null || !passwordValid)
            return new LoginResponseDtos()
            {
                AccessToken = string.Empty
            };
        var token = await _tokenServices.GenerateAccessTokenAsync(user);

        var refreshTokenNew = new RefreshToken
        {
            Token = await _tokenServices.GenerateRefreshTokenAsync(),
            Expriaton = DateTime.UtcNow.AddDays(30),//30 ngay
            UserId = user.Id
        };
        var refeshTokenDatabase = await _supermarketDbContext.RefreshTokens.FirstOrDefaultAsync(u => u.UserId == user.Id);
        if (refeshTokenDatabase == null)
        {
            await _tokenServices.CreateRefreshTokenAsync(refreshTokenNew);
            return new LoginResponseDtos()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationAT = token.ValidTo,
                RefreshToken = refreshTokenNew.Token,
                ExpirationRT = refreshTokenNew.Expriaton
            };
        }

        if (refeshTokenDatabase.Expriaton < DateTime.UtcNow)
            await _tokenServices.UpdateRefreshTokenAsync(refeshTokenDatabase,refeshTokenDatabase.Id);
        return new LoginResponseDtos()
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
            ExpirationAT = token.ValidTo,
            RefreshToken = refeshTokenDatabase.Token,
            ExpirationRT = refeshTokenDatabase.Expriaton
        };
    }

    public async Task<IdentityResult> SignUpAsync(UserRequestDto userRequestDtos)
    {
        if (userRequestDtos.Password != userRequestDtos.ConfirmPassword)
        {
            return IdentityResult.Failed(new IdentityError { Code = "PasswordConfirmation", Description = "Passwords không giống." });
        }
        var user = _mapper.Map<AppUser>(userRequestDtos);
        user.PasswordHash = userRequestDtos.Password;
        var result = await _userManager.CreateAsync(user, user.PasswordHash);
        if (result.Succeeded)
        {
            if (!await _roleManager.RoleExistsAsync("Salesperson"))
                await _roleManager.CreateAsync(new IdentityRole<int>("Salesperson"));

            await _userManager.AddToRoleAsync(user, "Salesperson");
            return IdentityResult.Success;
        }
        return result;
    }
    public async Task<LoginResponseDtos> RenewTokenAsync(LoginTokenRequestDtos loginTokenRequest)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var secretKeyBytes = Encoding.UTF8.GetBytes(_jsonWebTokenSettings.SecretKey);
        var param = new TokenValidationParameters
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
            var tokenInVerification =
                jwtTokenHandler.ValidateToken(loginTokenRequest.AccessToken, param, out var validatedToken);
            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                //check 2 : kiem tra ma hoa
                var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase);
                if (!result) return null;
            }

            //check 3 : check han accesstoken
            var utcExpireDate = long.Parse(tokenInVerification.Claims
                .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expriceDate = ConvertUtcTime(utcExpireDate);
            if (expriceDate > DateTime.UtcNow) return null;

            //check 4 : Refesh co ton tai khong
            var storeRefeshToken =
                _supermarketDbContext.RefreshTokens.FirstOrDefault(x => x.Token == loginTokenRequest.RefreshToken);
            if (storeRefeshToken is null)
            {
                return null;
            }

            if (storeRefeshToken.Expriaton < DateTime.UtcNow)
                return null;
            var user = await _supermarketDbContext.Users.FirstOrDefaultAsync(x => x.Id == storeRefeshToken.UserId);
            var token = await _tokenServices.GenerateAccessTokenAsync(user);
            var AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new LoginResponseDtos()
            {
                AccessToken = AccessToken,
                ExpirationAT = token.ValidTo,
                RefreshToken = storeRefeshToken.Token,
                ExpirationRT = storeRefeshToken.Expriaton
            };
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
        dateTimeInterval = dateTimeInterval.AddSeconds(utcTime).ToUniversalTime();
        return dateTimeInterval;
    }
}