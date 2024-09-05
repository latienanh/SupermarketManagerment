namespace Supermarket.Application.ModelResponses;

public class ResponseWithListSuccess<T> : ResponseSuccess
{
    public ResponseWithListSuccess()
    {
        ListData = new List<T>();
    }

    public IEnumerable<T> ListData { get; set; }
}