using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Supermarket.Application.Abstractions.Token;
using Supermarket.Application.Settings;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Domain.Entities.Token;

namespace Supermarket.Application.Services.Authentication.Commands.Token
{
    public class TokenCommandService: ITokenCommand
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly JsonWebTokenSetting _jsonWebTokenSetting;

        public TokenCommandService(IRefreshTokenRepository refreshTokenRepository,
            UserManager<AppUser> userManager,
            JsonWebTokenSetting jsonWebTokenSetting)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
            _jsonWebTokenSetting = jsonWebTokenSetting;
        }
        public async Task<RefreshToken> CreateRefreshTokenAsync(RefreshToken refreshToken)
        {
            return await _refreshTokenRepository.AddAsync(refreshToken);
        }

        public async Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken, Guid id)
        {
            return await _refreshTokenRepository.UpdateAsync(refreshToken, id);
        }

        public async Task<string> GenerateRefreshTokenAsync()
        {
            var randomNumber = new byte[64];
            using var generate = RandomNumberGenerator.Create();
            generate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
