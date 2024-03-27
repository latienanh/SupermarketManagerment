namespace Supermarket.Infrastructure.DbFactories;

public interface IDbFactory : IDisposable
{
    SuperMarketDbContext Init();
}