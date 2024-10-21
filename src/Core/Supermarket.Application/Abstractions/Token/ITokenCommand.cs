using Supermarket.Domain.Entities.Token;

namespace Supermarket.Application.Abstractions.Token
{
    public interface ITokenCommand
    {
        Task<RefreshToken> CreateRefreshTokenAsync(RefreshToken refreshToken);
        Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken, Guid id);
        Task<string> GenerateRefreshTokenAsync();


    }
}
