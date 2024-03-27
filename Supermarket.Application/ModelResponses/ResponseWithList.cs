namespace Supermarket.Application.ModelResponses;

public class ResponseWithList<T> : ResponseBase
{
    public ResponseWithList()
    {
        ListData = new List<T>();
    }

    public ICollection<T> ListData { get; set; }
}