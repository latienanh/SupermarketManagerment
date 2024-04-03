using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.DTOs.Auth.RequestDtos
{
    public class LoginTokenRequestDtos
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
