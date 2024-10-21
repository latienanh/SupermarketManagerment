using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.Token;
using Supermarket.Infrastructure.DbContext;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories;

public class RefreshTokenRepository : RepositoryBaseBasic<RefreshToken>,IRefreshTokenRepository
{
    protected IDbFactory DbFactory;
    private SuperMarketDbContext _dbContext;
    public SuperMarketDbContext _superMarketDbContext => _dbContext??(_dbContext=DbFactory.Init());

    public RefreshTokenRepository(IDbFactory dbFactory): base(dbFactory)
    {
        DbFactory = dbFactory;
    }
    public async Task<RefreshToken> GetByTokenAsync(string token)
    {
            var entity = await _superMarketDbContext.RefreshTokens.FirstOrDefaultAsync(x => x.Token==token);
            return entity;
    }

    public async Task<RefreshToken> GetByUserIdAsync(Guid userId)
    {
        var entity = await _superMarketDbContext.RefreshTokens.FirstOrDefaultAsync(x => x.UserId == userId);
        return entity;
    }
}