﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.Services;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Infrastructure.DbFactories;
using Supermarket.Infrastructure.Repositories;
using Supermarket.Infrastructure.Settings;
using Supermarket.Infrastructure.UnitOfWorks;
using System.Reflection;

namespace Supermarket.Infrastructure;

public static class DependencyInjection
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

    public static IServiceCollection AddRepository(this IServiceCollection service)
    {
        service.AddScoped<IAttributeRepository, AttributeRepository>();
        service.AddScoped<IAttributeValueRepository, AttributeValueRepository>();
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddScoped<IAuthRepository, AuthRepository>();
        service.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        service.AddScoped<IRoleRepository, RoleRepository>();
        service.AddScoped<IUserRepository<UserRequestDto,UserResponseDto>, UserRepository>();
        service.AddScoped<IProductRepository, ProductRepository>();
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