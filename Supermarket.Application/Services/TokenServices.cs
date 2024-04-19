using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.Settings;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Domain.Entities.Token;

namespace Supermarket.Application.Services;

public class TokenServices : ITokenServices
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly UserManager<AppUser> _userManager;
    private ITokenServices _tokenServicesImplementation;

    public TokenServices(IRefreshTokenRepository refreshTokenRepository,
        UserManager<AppUser> userManager,
        JsonWebTokenSetting jsonWebTokenSetting)
    {
        _jsonWebTokenSettings = jsonWebTokenSetting;
        _refreshTokenRepository = refreshTokenRepository;
        _userManager = userManager;
    }

    public JsonWebTokenSetting _jsonWebTokenSettings { get; }

    public async Task<bool> ValidateRefreshTokenAsync(string token)
    {
        return await _refreshTokenRepository.ValidateRefreshTokenAsync(token);
    }

    public async Task<RefreshToken> CreateRefreshTokenAsync(RefreshToken refreshToken)
    {
        return await _refreshTokenRepository.AddAsync(refreshToken);
    }

    public async Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken, Guid id)
    {
        return await _refreshTokenRepository.UpdateAsync(refreshToken,id);
    }

    public async Task<string> GenerateRefreshTokenAsync()
    {
        var randomNumber = new byte[64];
        using var generate = RandomNumberGenerator.Create();
        generate.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public async Task<JwtSecurityToken> GenerateAccessTokenAsync(AppUser user)
    {
        var authClaim = new List<Claim>
        {
            new("UserId", user.Id.ToString()),
            new(ClaimTypes.Email, user.UserName),

            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var userRoles = await _userManager.GetRolesAsync(user);
        foreach (var userRole in userRoles) authClaim.Add(new Claim(ClaimTypes.Role, userRole));
        var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jsonWebTokenSettings.SecretKey));

        var token = new JwtSecurityToken(
            _jsonWebTokenSettings.ValidIssuer,
            _jsonWebTokenSettings.ValidAudience,
            expires: DateTime.UtcNow.AddMinutes(30),//30p
            claims: authClaim,
            signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256)
        );
        return token;
    }
}