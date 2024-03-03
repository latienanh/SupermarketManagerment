using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Infrastructure.Settings
{
    public class SupermarketDbContextSettings
    {
        public const string SettingName = "ConnectionStrings";
        public string DefaultConnection { get; set; }
    }
}
