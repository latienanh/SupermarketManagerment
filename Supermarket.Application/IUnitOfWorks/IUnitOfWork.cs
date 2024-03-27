namespace Supermarket.Application.UnitOfWork;

public interface IUnitOfWork
{
    void Commit();
    Task CommitAsync();
}