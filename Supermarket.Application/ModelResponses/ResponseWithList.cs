namespace Supermarket.Application.ModelResponses;

public class ResponseWithList<T> : ResponseBase
{
    public ResponseWithList()
    {
        ListData = new List<T>();
    }

    public IEnumerable<T> ListData { get; set; }
}