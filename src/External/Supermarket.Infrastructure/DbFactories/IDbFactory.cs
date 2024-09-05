using Supermarket.Infrastructure.DbContext;

namespace Supermarket.Infrastructure.DbFactories;

public interface IDbFactory : IDisposable
{
    SuperMarketDbContext Init();
}