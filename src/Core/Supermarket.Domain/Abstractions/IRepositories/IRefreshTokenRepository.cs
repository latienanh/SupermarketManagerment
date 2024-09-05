using Supermarket.Domain.Entities.Token;

namespace Supermarket.Domain.Abstractions.IRepositories;

public interface IRefreshTokenRepository: IBasicRepository<RefreshToken>
{
    Task<bool> ValidateRefreshTokenAsync(string token);
    //Task<RefreshToken> CreateRefreshTokenAsync(RefreshToken refreshToken);
    //Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken);
}