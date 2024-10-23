using System.Text;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Supermarket.Api.Middleware;
using Supermarket.Application;
using Supermarket.Application.Behaviors;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Infrastructure;
using Supermarket.Infrastructure.DbContext;
using Supermarket.Presentation.Hubs;

namespace Supermarket.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Lấy cấu hình từ appsettings.json và secret
        var configuration = builder.Configuration;
        // Đăng ký các dịch vụ cần thiết
        var presentation = typeof(Supermarket.Presentation.AssemblyReference).Assembly;
        builder.Services.AddControllers().AddApplicationPart(presentation);
        builder.Services.AddAplication(configuration);
        builder.Services.AddJWTRepository(configuration);
        builder.Services.AddSqlRepository(configuration);
        builder.Services.AddMongoDBRepository(configuration);

        var application = typeof(Supermarket.Application.AssemblyReference).Assembly;
        builder.Services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(application))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviors<,>))
            .AddValidatorsFromAssembly(application);

        // Đăng ký Middleware tùy chỉnh
        builder.Services.AddScoped<Custom401ReponseMiddleware>();
        builder.Services.AddScoped<Custom403ResponseMiddleware>();
        builder.Services.AddScoped<HandleExceptionMiddleware>();

        // Cấu hình Identity
        builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<SuperMarketDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddScoped<RoleManager<IdentityRole<Guid>>, RoleManager<IdentityRole<Guid>>>();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            // Thiết lập mật khẩu
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 1;

            // Cấu hình Lockout - khóa user
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // Cấu hình về User
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;

            // Cấu hình đăng nhập
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        });

        // Cấu hình Cors
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("MyCrossOriginResourceSharing",
                builder =>
                {
                    builder.WithOrigins(configuration["Client_URL"])
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithHeaders("Content-Type");
                });
        });

        // Cấu hình Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Supermarket API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        // Cấu hình Authentication và Authorization
        builder.Services.AddAuthorization();
        builder.Services
            .AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = configuration["JsonWebToken:ValidIssuer"],
                    ValidAudience = configuration["JsonWebToken:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JsonWebToken:SecretKey"])),
                    ClockSkew = TimeSpan.FromSeconds(5)
                };
            });

        // Đăng ký các dịch vụ khác
        builder.Services.AddAbstractions();
        builder.Services.AddRepository();
        builder.Services.AddDbFactory();
        builder.Services.AddUnitOfWork();

        builder.Services.AddSignalR();

        var app = builder.Build();

        // Cấu hình middleware và pipeline xử lý yêu cầu HTTP
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseCors("MyCrossOriginResourceSharing");
        app.UseAuthentication();
        app.UseMiddleware<Custom401ReponseMiddleware>();
        app.UseMiddleware<Custom403ResponseMiddleware>();
        app.UseAuthorization();
        app.MapControllers();
        app.UseMiddleware<HandleExceptionMiddleware>();
        app.MapHub<ReportHub>("/reportHub");
        app.Run();
    }
}
