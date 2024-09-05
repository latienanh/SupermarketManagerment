using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Infrastructure.DbContext;
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

    public void Commit(CancellationToken cancellationToken)
    {
        try
        {
            if (cancellationToken.IsCancellationRequested)
                cancellationToken.ThrowIfCancellationRequested();
            DbContext.SaveChanges();
        }
        catch (OperationCanceledException e)
        {
            string log = e.Message;
            throw;
        }
    }



    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        try
        {
            if (cancellationToken.IsCancellationRequested)
                cancellationToken.ThrowIfCancellationRequested();
            await DbContext.SaveChangesAsync(cancellationToken);
        }
        catch (OperationCanceledException e)
        {
            string log = e.Message;
            throw;
        }

    }
}