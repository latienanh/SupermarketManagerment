using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.ModelResponses
{
    public class ResponseSuccess : ResponseBase
    {
        public string Type { get; set; } = HttpResponseType.Ok;
        public string Title { get; set; } = "Thành công";
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
        public string? Message { get; set; }

    }
}
