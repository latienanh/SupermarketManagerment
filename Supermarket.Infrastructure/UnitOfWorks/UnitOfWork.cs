using Supermarket.Application.UnitOfWork;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbFactory _dbFactory;
    private SuperMarketDbContext dbContext;

    public UnitOfWork(IDbFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public SuperMarketDbContext DbContext => dbContext ??= _dbFactory.Init();

    public void Commit()
    {
        DbContext.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await DbContext.SaveChangesAsync();
    }
}