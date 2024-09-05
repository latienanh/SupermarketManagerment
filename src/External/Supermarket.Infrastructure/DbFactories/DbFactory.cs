using Microsoft.EntityFrameworkCore;
using Supermarket.Infrastructure.DbContext;

namespace Supermarket.Infrastructure.DbFactories;

public class DbFactory : Disposable, IDbFactory
{
    private SuperMarketDbContext dbContext;
    private readonly DbContextOptions<SuperMarketDbContext> dbOptions;

    public DbFactory(DbContextOptions<SuperMarketDbContext> options)
    {
        dbOptions = options;
    }

    public SuperMarketDbContext Init()
    {
        return dbContext ?? (dbContext = new SuperMarketDbContext(dbOptions));
    }

    protected override void DisposeCore()
    {
        if (dbContext != null)
            dbContext.Dispose();
    }
}