using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.Token;
using Supermarket.Infrastructure.DbContext;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories;

public class RefreshTokenRepository : RepositoryBaseBasic<RefreshToken>,IRefreshTokenRepository
{
    private readonly SuperMarketDbContext _superMarketDbContext;

    public RefreshTokenRepository(IDbFactory dbFactory): base(dbFactory)
    {
        
    }

    //public async Task<RefreshToken> CreateRefreshTokenAsync(RefreshToken refreshToken)
    //{
    //    await _superMarketDbContext.RefreshTokens.AddAsync(refreshToken);
    //    await _superMarketDbContext.SaveChangesAsync();
    //    return refreshToken;
    //}

    //public async Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken)
    //{
    //    var updateRefeshToken =
    //        await _superMarketDbContext.RefreshTokens.FirstOrDefaultAsync(m => m.UserId == refreshToken.UserId);
    //    if (updateRefeshToken != null)
    //    {
    //        updateRefeshToken.Token = refreshToken.Token;
    //        updateRefeshToken.Expriaton = refreshToken.Expriaton;
    //        await _superMarketDbContext.SaveChangesAsync();
    //        return refreshToken;
    //    }

    //    return null;
    //}

    public async Task<bool> ValidateRefreshTokenAsync(string token)
    {
        throw new NotImplementedException();
    }
}