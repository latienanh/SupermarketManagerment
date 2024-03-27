namespace Supermarket.Application.ModelResponses;

public class ResponseWithData<T> : ResponseBase
{
    public T Data { get; set; }
}