using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Supermarket.Infastructure;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

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
    }
}
