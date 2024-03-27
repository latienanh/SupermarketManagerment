using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Application.IServices;
using Supermarket.Application.Services;
using Supermarket.Application.Settings;

namespace Supermarket.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection service, IConfiguration configuration)
    {
        var jsonWebTokenSetting = new JsonWebTokenSetting();
        configuration.GetSection(JsonWebTokenSetting.SettingName).Bind(jsonWebTokenSetting);
        service.AddSingleton(jsonWebTokenSetting);
        return service;
    }

    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddScoped<IAttributeServices, AttributeServices>();
        service.AddScoped<IAttributeValueServices, AttributeValueServices>();
        return service;
    }
}