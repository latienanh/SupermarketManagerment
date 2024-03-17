using Supermarket.Domain.Entities.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.Auth;
using Supermarket.Application.ModelResponses;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.IServices
{
    public interface ITokenServices
    {
            Task<bool> ValidateRefreshTokenAsync(string token);
            Task<RefreshToken> CreateRefreshTokenAsync(RefreshToken refreshToken);
            Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken);
            Task<string> GenerateRefreshTokenAsync();
            Task<JwtSecurityToken> GenerateAccessTokenAsync(AppUser user);
    }
}
