using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Domain.Entities.Token;
using Supermarket.Infrastructure.DbFactories;
using Supermarket.Infrastructure.Settings;

namespace Supermarket.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    //private readonly JsonWebTokenSettings _jsonWebTokenSettings;
    //private readonly IMapper _mapper;
    //private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    //private readonly SignInManager<AppUser> _signInManager;
    ////private readonly ITokenServices _tokenServices;
    //private readonly UserManager<AppUser> _userManager;
    //private readonly IDbFactory _dbFactory;
    //private SuperMarketDbContext _dataContext;
    //protected SuperMarketDbContext _supermarketDbContext => _dataContext ?? (_dataContext = _dbFactory.Init());
    //public AuthRepository(
    //    UserManager<AppUser> userManager,
    //    IDbFactory dbFactory,
    //    SignInManager<AppUser> signInManager,
    //    JsonWebTokenSettings jsonWebTokenSettings,
    //    RoleManager<IdentityRole<Guid>> roleManager,
    //    SuperMarketDbContext supermarketDbContext,
    //    //ITokenServices tokenServices,
    //    IMapper mapper)
    //{
    //    _userManager = userManager;
    //    _dbFactory = dbFactory;
    //    _signInManager = signInManager;
    //    _jsonWebTokenSettings = jsonWebTokenSettings;
    //    _roleManager = roleManager;
    //    //_tokenServices = tokenServices;
    //    _mapper = mapper;
    //}

    //public async Task<LoginResponseDtos?> LoginAsync(LoginBasicRequestDtos loginBasicRequestDtos)
    //{
    //    var user = await _userManager.FindByNameAsync(loginBasicRequestDtos.UserName);
    //    if (user == null)
    //        return null;
    //    var passwordValid = await _userManager.CheckPasswordAsync(user, loginBasicRequestDtos.Password);
    //    if (user == null || !passwordValid)
    //        return null;
    //    var token = await _tokenServices.GenerateAccessTokenAsync(user);
    //    var refreshTokenDatabase = await _supermarketDbContext.RefreshTokens.FirstOrDefaultAsync(u => u.UserId == user.Id);
    //    if (refreshTokenDatabase == null)
    //    {
    //        var refreshTokenNew = new RefreshToken
    //        {
    //            Token = await _tokenServices.GenerateRefreshTokenAsync(),
    //            Expriaton = DateTime.UtcNow.AddDays(30),//30 ngay
    //            UserId = user.Id
    //        };
    //        await _tokenServices.CreateRefreshTokenAsync(refreshTokenNew);
    //        return new LoginResponseDtos()
    //        {
    //            AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
            
    //            RefreshToken = refreshTokenNew.Token,
              
    //        };
    //    }

    //    if (refreshTokenDatabase.Expriaton < DateTime.UtcNow)
    //    {
    //        var refreshTokenNew = new RefreshToken
    //        {
    //            Token = await _tokenServices.GenerateRefreshTokenAsync(),
    //            Expriaton = DateTime.UtcNow.AddDays(30),//30 ngay
    //            UserId = user.Id
    //        };
    //        await _tokenServices.UpdateRefreshTokenAsync(refreshTokenNew, refreshTokenDatabase.Id);
    //        return new LoginResponseDtos()
    //        {
    //            AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
              
    //            RefreshToken = refreshTokenNew.Token,
         
    //        };
    //    }

    //    return new LoginResponseDtos()
    //    {
    //        AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
       
    //        RefreshToken = refreshTokenDatabase.Token,
     
    //    };

    //}

    //public async Task<IdentityResult> SignUpAsync(SignUpRequestDto signUpRequestDto)
    //{
    //    //if (signUpRequestDto.Password != signUpRequestDto.ConfirmPassword)
    //    //{
    //    //    return IdentityResult.Failed(new IdentityError { Code = "PasswordConfirmation", Description = "Passwords không giống." });
    //    //}
    //    var user = _mapper.Map<AppUser>(signUpRequestDto);
    //    user.Image = signUpRequestDto.PathImage;
    //    user.PasswordHash = signUpRequestDto.Password;
    //    var result = await _userManager.CreateAsync(user, user.PasswordHash);
    //    if (result.Succeeded)
    //    {
    //        if (!await _roleManager.RoleExistsAsync(RoleBase.Cashier))
    //            await _roleManager.CreateAsync(new IdentityRole<Guid>(RoleBase.Cashier));

    //        await _userManager.AddToRoleAsync(user, RoleBase.Cashier);
    //        return IdentityResult.Success;
    //    }
    //    return result;
    //}
    //public async Task<LoginResponseDtos> RenewTokenAsync(LoginTokenRequestDtos loginTokenRequest)
    //{
    //    var jwtTokenHandler = new JwtSecurityTokenHandler();
    //    var secretKeyBytes = Encoding.UTF8.GetBytes(_jsonWebTokenSettings.SecretKey);
    //    var param = new TokenValidationParameters
    //    {
    //        ValidateIssuer = true,
    //        ValidateAudience = true,
    //        ValidIssuer = _jsonWebTokenSettings.ValidIssuer,
    //        ValidAudience = _jsonWebTokenSettings.ValidAudience,
    //        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
    //        ClockSkew = new TimeSpan(0, 0, 5),
    //        ValidateLifetime = false
    //    };
    //    try
    //    {
    //        //check 1 :AccessToken Validate 
    //        var tokenInVerification =
    //            jwtTokenHandler.ValidateToken(loginTokenRequest.AccessToken, param, out var validatedToken);
    //        if (validatedToken is JwtSecurityToken jwtSecurityToken)
    //        {
    //            //check 2 : kiem tra ma hoa
    //            var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
    //                StringComparison.InvariantCultureIgnoreCase);
    //            if (!result) return null;
    //        }

    //        //check 3 : check han accesstoken
    //        var utcExpireDate = long.Parse(tokenInVerification.Claims
    //            .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
    //        var expriceDate = ConvertUtcTime(utcExpireDate);
    //        if (expriceDate > DateTime.UtcNow) return null;

    //        //check 4 : Refesh co ton tai khong
    //        var storeRefeshToken =
    //            _supermarketDbContext.RefreshTokens.FirstOrDefault(x => x.Token == loginTokenRequest.RefreshToken);
    //        if (storeRefeshToken is null)
    //        {
    //            return null;
    //        }

    //        if (storeRefeshToken.Expriaton < DateTime.UtcNow)
    //            return null;
    //        var user = await _supermarketDbContext.Users.FirstOrDefaultAsync(x => x.Id == storeRefeshToken.UserId);
    //        var token = await _tokenServices.GenerateAccessTokenAsync(user);
    //        var AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
    //        return new LoginResponseDtos()
    //        {
    //            AccessToken = AccessToken,
    //            RefreshToken = storeRefeshToken.Token,
    //        };
    //    }
    //    catch (Exception e)
    //    {
    //        Console.WriteLine(e);
    //        return null;
    //    }
    //}

    //public async Task<bool> LogOut(Guid id)
    //{
    //    var currentTime = DateTime.UtcNow;
    //    var refreshToken = await _supermarketDbContext.RefreshTokens.FirstOrDefaultAsync((r) => r.UserId == id);
    //    if (refreshToken == null || refreshToken.Expriaton< currentTime)
    //    {
    //        // Refresh token không tồn tại hoặc đã hết hạn, không cần xóa
    //        return false;
    //    }
    //    _supermarketDbContext.RefreshTokens.Remove(refreshToken);
    //    //await _supermarketDbContext.SaveChangesAsync();
    //    return true;

    //}

    //public DateTime ConvertUtcTime(long utcTime)
    //{
    //    var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    //    dateTimeInterval = dateTimeInterval.AddSeconds(utcTime).ToUniversalTime();
    //    return dateTimeInterval;
    //}
}