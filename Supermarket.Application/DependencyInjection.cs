using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Application.IServices;
using Supermarket.Application.Services;
using Supermarket.Application.Settings;

namespace Supermarket.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection service,IConfiguration configuration)
        {
            JsonWebTokenSetting jsonWebTokenSetting = new JsonWebTokenSetting();
            configuration.GetSection(JsonWebTokenSetting.SettingName).Bind(jsonWebTokenSetting);
            service.AddSingleton(jsonWebTokenSetting);
            return service;
        }
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IAttributeServices, AttributeServices>();
            return service;
        }
    }
}
