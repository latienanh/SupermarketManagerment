namespace Supermarket.Application.ModelResponses;

public class ResponseWithDataSuccess<T> : ResponseSuccess
{
    public T Data { get; set; }
}