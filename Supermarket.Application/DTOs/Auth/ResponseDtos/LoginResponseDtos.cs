using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.DTOs.Auth.ResponseDtos
{
    public class LoginResponseDtos
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationAT { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationRT { get; set; }
    }
}
