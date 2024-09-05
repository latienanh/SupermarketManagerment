namespace Supermarket.Application.ModelResponses
{
    public class ResponseWithDataFailure<T> : ResponseFailure
    {
        public T Data { get; set; }
    }
}
