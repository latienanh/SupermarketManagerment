using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.ModelResponses
{
    public class ResponseFailure : ResponseBase
    {
        public string Type { get; set; } = HttpResponseType.BadRequest;
        public string Title { get; set; } = "Thất bại";
        public HttpStatusCode Status { get; set; } = HttpStatusCode.BadRequest;
        public string? Message { get; set; }
    }
}
