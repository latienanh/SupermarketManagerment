using Supermarket.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Supermarket.Application.Abstractions.Token
{
    public interface ITokenQuery
    {
        //Task<bool> ValidateRefreshTokenAsync(string token);
        Task<JwtSecurityToken> GenerateAccessTokenAsync(AppUser user);
    }
}
