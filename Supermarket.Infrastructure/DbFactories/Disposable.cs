namespace Supermarket.Infrastructure.DbFactories;

public class Disposable : IDisposable
{
    private bool isDisposed;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~Disposable()
    {
        Dispose(false);
    }

    private void Dispose(bool disposing)
    {
        if (!isDisposed && disposing) DisposeCore();

        isDisposed = true;
    }

    // Ovveride this to dispose custom objects
    protected virtual void DisposeCore()
    {
    }
}