using System.Text;
using DotNetEnv.Configuration;
using HouseFinder360.Application.Common.Interfaces.Authentication;
using HouseFinder360.Application.Common.Interfaces.Persistence;
using HouseFinder360.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.Application.Common.Interfaces.Services;
using HouseFinder360.Infrastructure.Authentication;
using HouseFinder360.Infrastructure.Persistence;
using HouseFinder360.Infrastructure.Persistence.Generic;
using HouseFinder360.Infrastructure.Persistence.Repositories;
using HouseFinder360.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HouseFinder360.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        builderConfiguration.AddDotNetEnv();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services
            .AddAuth(builderConfiguration)
            .AddPersistence();
        return services;
    }

    private static void AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<HouseFinder360DbContext>(options => 
            options.UseNpgsql(CreateConnectionString()).EnableSensitiveDataLogging());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static string CreateConnectionString()
    {
        var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5431";
        var database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "postgres";
        var username = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "postgres";
        var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "housefinder365";
        return $"Server={server};Port={port};Database={database};Username={username};Password={password}";
    }
    private static IServiceCollection AddAuth(this IServiceCollection services,
        IConfiguration builderConfiguration)
    {
        var jwtSettings = new JwtSettings();
        builderConfiguration.Bind(JwtSettings.SectionName,jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
              ValidateAudience  = true,
              ValidateIssuer = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = jwtSettings.Issuer,
              ValidAudience = jwtSettings.Audience,
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")!))
            });
        return services;
    }
}