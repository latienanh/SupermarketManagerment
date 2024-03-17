using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.ModelResponses
{
    public class APIReponseBase<T>
    {
        public int response_status { get; set; }
        public string response_message { get; set; }
        public T response_data { get; set; }
    }
}
