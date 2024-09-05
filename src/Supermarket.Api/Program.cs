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
using Supermarket.Application.Profiles;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Infrastructure;
using Supermarket.Infrastructure.DbContext;

namespace Supermarket.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        var configuration = builder.Configuration;

        var presentation =  typeof(Supermarket.Presentation.AssemblyReference).Assembly;
        builder.Services.AddControllers().AddApplicationPart(presentation);
        builder.Services.AddAplication(configuration);
        builder.Services.AddJWTRepository(configuration);
        builder.Services.AddSqlRepository(configuration);

        var application = typeof(Supermarket.Application.AssemblyReference).Assembly;

        builder.Services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(application))
            .AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehaviors<,>))
            .AddValidatorsFromAssembly(application);

        builder.Services.AddScoped<Custom401ReponseMiddleware>();
        builder.Services.AddScoped<Custom403ResponseMiddleware>();
        builder.Services.AddScoped<HandleExceptionMiddleware>();

        builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<SuperMarketDbContext>()
            .AddDefaultTokenProviders();
        builder.Services.AddScoped<RoleManager<IdentityRole<Guid>>, RoleManager<IdentityRole<Guid>>>();
        builder.Services.Configure<IdentityOptions>(options =>
        {
            // Thiết lập về Password
            options.Password.RequireDigit = false; // Không bắt phải có số
            options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
            options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
            options.Password.RequireUppercase = false; // Không bắt buộc chữ in
            options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
            options.Password.RequiredUniqueChars = 1; //Số ký tự riêng biệt

            // Cấu hình Lockout - khóa user
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
            options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
            options.Lockout.AllowedForNewUsers = true;

            // Cấu hình về User.
            options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true; // Email là duy nhất

            // Cấu hình đăng nhập.
            options.SignIn.RequireConfirmedEmail = false; // Cấu hình xác thực địa chỉ email (email phải tồn tại)
            options.SignIn.RequireConfirmedPhoneNumber = false; // Xác thực số điện thoại
        });

        //builder.Services.AddCors(p => p.AddPolicy("MyCrossOriginResourceSharing",
        //    build => build.WithOrigins("*").AllowAnyMethod().WithHeaders()));
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("MyCrossOriginResourceSharing",
                builder =>
                {
                    builder.WithOrigins(configuration["Client_URL"])
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithHeaders("Content-Type"); // Thêm tiêu đề Content-Type vào danh sách các tiêu đề cho phép
                });
        });


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Book API", Version = "v1" });
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
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JsonWebToken:SecretKey"])),
                    ClockSkew = new TimeSpan(0, 0, 5)
                };
            });
        //builder.Services.ConfigureCustomMiddleware();

        builder.Services.AddServices();
        builder.Services.AddRepository();
        builder.Services.AddDbFactory();
        builder.Services.AddUnitOfWork();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
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
        app.Run();
    }

    //public static IServiceCollection ConfigureCustomMiddleware(this IServiceCollection services)
    //{
    //    services.AddScoped<Custom401ReponseMiddleware>();
    //    services.AddScoped<Custom403ResponseMiddleware>();
    //    services.AddScoped<HandleExceptionMiddleware>();
    //    return services;
    //}
}