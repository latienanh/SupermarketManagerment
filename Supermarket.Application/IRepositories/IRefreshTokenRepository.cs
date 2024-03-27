using Supermarket.Domain.Entities.Token;

namespace Supermarket.Application.IRepositories;

public interface IRefreshTokenRepository
{
    Task<bool> ValidateRefreshTokenAsync(string token);
    Task<RefreshToken> CreateRefreshTokenAsync(RefreshToken refreshToken);
    Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken);
}