using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.ModelResponses
{
    public class ResponseWithDataFailure<T> : ResponseFailure
    {
        public T Data { get; set; }
    }
}
