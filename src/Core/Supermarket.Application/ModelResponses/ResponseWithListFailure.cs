namespace Supermarket.Application.ModelResponses
{
    public class ResponseWithListFailure<T> :ResponseFailure
    {
        public ResponseWithListFailure()
        {
            ListData = new List<T>();
        }

        public IEnumerable<T> ListData { get; set; }
    }
}
