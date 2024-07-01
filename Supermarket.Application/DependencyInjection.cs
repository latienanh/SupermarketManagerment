using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Application.IRepositories;
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
        service.AddScoped<ICategoryServices, CategoryServices>();
        service.AddScoped<IAuthServices, AuthServices>();
        service.AddScoped<ITokenServices, TokenServices>();
        service.AddScoped<IRoleServices, RoleServices>();
        service.AddScoped<IUserServices, UserServices>();
        service.AddScoped<IProductServices, ProductServices>();
        service.AddScoped<ICouponServices, CouponServices>();
        service.AddScoped<IImageServices, ImageServices>();
        service.AddScoped<ICustomerServices, CustomerServices>();
        service.AddScoped<IMemberShipTypeServices, MemberShipTypeServices>();
        service.AddScoped<ISupplierServices, SupplierServices>();
        service.AddScoped<IEmployeeServices, EmployeeServices>();
        service.AddScoped<IImportGoodsServices, ImportGoodsServices>();
        service.AddScoped<ISalesService, SaleServices>();
        service.AddScoped<ISendMailServices, SendMailServices>();
        return service;
    }
}