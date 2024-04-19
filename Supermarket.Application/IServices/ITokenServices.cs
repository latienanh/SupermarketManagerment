using System.IdentityModel.Tokens.Jwt;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Domain.Entities.Token;

namespace Supermarket.Application.IServices;

public interface ITokenServices
{
    Task<bool> ValidateRefreshTokenAsync(string token);
    Task<RefreshToken> CreateRefreshTokenAsync(RefreshToken refreshToken);
    Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken,Guid id);
    Task<string> GenerateRefreshTokenAsync();
    Task<JwtSecurityToken> GenerateAccessTokenAsync(AppUser user);
}