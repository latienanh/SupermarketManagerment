namespace Supermarket.Domain.Abstractions.IUnitOfWorks;
public interface IUnitOfWork
{
    void Commit(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
}