using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Application.Abstractions.IImageservices;
using Supermarket.Application.Abstractions.ISendMailServices;
using Supermarket.Application.Abstractions.Token;
using Supermarket.Application.Services.Authentication.Commands.Token;
using Supermarket.Application.Services.Authentication.Queries.Token;
using Supermarket.Application.Services.Image;
using Supermarket.Application.Services.Mail.Command;
using Supermarket.Application.Settings;

namespace Supermarket.Application;

public static class AssemblyReference
{
    public static IServiceCollection AddAplication(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddAutoMapper(typeof(AssemblyReference));

        var jsonWebTokenSetting = new JsonWebTokenSetting();
        configuration.GetSection(JsonWebTokenSetting.SettingName).Bind(jsonWebTokenSetting);
        service.AddSingleton(jsonWebTokenSetting);
        return service;
    }

    public static IServiceCollection AddAbstractions(this IServiceCollection service)
    {
        service.AddScoped<ITokenCommand, TokenCommandService>();
        service.AddScoped<ITokenQuery, TokenQueryService>();
        service.AddScoped<IImageServices, ImageServices>();
        service.AddScoped<ISendMailServices, SendMailServices>();
        return service;
    }
   
}