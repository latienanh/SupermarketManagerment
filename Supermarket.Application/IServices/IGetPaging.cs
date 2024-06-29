namespace Supermarket.Application.IServices
{
    public interface IGetPaging<T>
    {
        Task<IEnumerable<T>> getPagingAsync(int index, int size);
        Task<int> getTotalPagingTask(int size);
    }
}
