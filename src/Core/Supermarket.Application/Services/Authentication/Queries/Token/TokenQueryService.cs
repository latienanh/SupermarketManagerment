using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.Abstractions.Token;
using Supermarket.Application.Settings;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.Services.Authentication.Queries.Token
{
    public class TokenQueryService:ITokenQuery
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly JsonWebTokenSetting _jsonWebTokenSetting;

        public TokenQueryService(IRefreshTokenRepository refreshTokenRepository,
            UserManager<AppUser> userManager,
            JsonWebTokenSetting jsonWebTokenSetting)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
            _jsonWebTokenSetting = jsonWebTokenSetting;
        }
        //public async Task<bool> ValidateRefreshTokenAsync(string token)
        //{
        //    return await _refreshTokenRepository.ValidateRefreshTokenAsync(token);
        //}

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
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jsonWebTokenSetting.SecretKey));

            var token = new JwtSecurityToken(
                _jsonWebTokenSetting.ValidIssuer,
                _jsonWebTokenSetting.ValidAudience,
                expires: DateTime.UtcNow.AddMinutes(30),//30p
                claims: authClaim,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }
    }
}
