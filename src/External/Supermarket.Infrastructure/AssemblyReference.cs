﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Infrastructure.DbFactories;
using Supermarket.Infrastructure.Repositories;
using Supermarket.Infrastructure.Settings;
using Supermarket.Infrastructure.UnitOfWorks;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Infrastructure.DbContext;

namespace Supermarket.Infrastructure;

public static class AssemblyReference
{
    public static IServiceCollection AddJWTRepository(this IServiceCollection services, IConfiguration configuration)
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
    public static IServiceCollection AddMongoDBRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<SupermarketMongoDbContext>();
        return services;
    }

    public static IServiceCollection AddRepository(this IServiceCollection service)
    {
        service.AddScoped<IAttributeRepository, AttributeRepository>();
        service.AddScoped<IVariantValueRepository, VariantValueRepository>();
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        service.AddScoped<IRoleRepository, RoleRepository>();
        service.AddScoped<IUserRepository<AppUser>, UserRepository>();
        service.AddScoped<IProductRepository, ProductRepository>();
        service.AddScoped<ICouponRepository, CouponRepository>();
        service.AddScoped<ICustomerRepository, CustomerRepository>();
        service.AddScoped<IMemberShipTypeRepository, MemberShipTypeRepository>();
        service.AddScoped<ISupplierRepository, SupplierRepository>();
        service.AddScoped<IEmployeeRepository, EmployeeRepository>();
        service.AddScoped<IStockInRepository, StockInRepository>();
        service.AddScoped<IStockInDetailRepository, StockInDetailRepository>();
        service.AddScoped<IInvoiceRepository, InvoiceRepository>();
        service.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
        return service;
    }
    public static IServiceCollection AddDbFactory(this IServiceCollection service)
    {
        service.AddScoped<IDbFactory, DbFactory>();
        return service;
    }
    public static IServiceCollection AddUnitOfWork(this IServiceCollection service)
    {
        service.AddScoped<IUnitOfWork,UnitOfWork>();
        return service;
    }
}