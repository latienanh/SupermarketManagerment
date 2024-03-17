using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.Settings
{
    public class JsonWebTokenSetting
    {
            public const string SettingName = "JsonWebToken";
            public string ValidIssuer { get; set; }
            public string ValidAudience { get; set; }
            public string SecretKey { get; set; }
    }
}
