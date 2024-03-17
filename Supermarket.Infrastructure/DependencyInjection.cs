using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Application.IRepositories;
using Supermarket.Infrastructure.Settings;
using Supermarket.Infastructure;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Supermarket.Application.IServices;
using Supermarket.Application.Services;
using Supermarket.Infrastructure.Repsitories;

namespace Supermarket.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddJWTRepository( this IServiceCollection services,IConfiguration configuration)
        {
            var JWTSetting = new JsonWebTokenSettings();
            configuration.GetSection(JsonWebTokenSettings.SettingName).Bind(JWTSetting);
            services.AddSingleton(JWTSetting);
            return services;
        }
        public static IServiceCollection AddSqlRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var DbContext = new SupermarketDbContextSettings();
            configuration.GetSection(SupermarketDbContextSettings.SettingName).Bind(DbContext);
            services.AddSingleton(DbContext);
            services.AddDbContext<SuperMarketDbContext>(options =>
            {
                options.UseSqlServer(DbContext.DefaultConnection,
                    b => b.MigrationsAssembly("Supermarket.Infrastructure"));
            });
            return services;
        }
        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
            service.AddScoped<IAttributeRepository, AttributeRepository>();
            return service;
        }
    }
}
