using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
