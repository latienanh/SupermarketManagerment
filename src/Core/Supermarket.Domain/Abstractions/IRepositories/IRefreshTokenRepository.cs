using Supermarket.Domain.Entities.Token;

namespace Supermarket.Domain.Abstractions.IRepositories;

public interface IRefreshTokenRepository: IBasicRepository<RefreshToken>
{
    Task<RefreshToken> GetByTokenAsync(string token);
    Task<RefreshToken> GetByUserIdAsync(Guid userId);
}