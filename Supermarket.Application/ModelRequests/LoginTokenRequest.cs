using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.ModelRequests
{
    public class LoginTokenRequest
    {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
            //public DateTime ExpirationRT { get; set; }
    }
}
