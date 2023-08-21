using System.Text;
using DotNetEnv.Configuration;
using HouseFinder360.Application.Common.BlobStorage;
using HouseFinder360.Application.Common.Interfaces.Authentication;
using HouseFinder360.Application.Common.Interfaces.Persistence;
using HouseFinder360.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.Application.Common.Interfaces.Services;
using HouseFinder360.Infrastructure.Authentication;
using HouseFinder360.Infrastructure.Common.Blob;
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
        
        services.Configure<BlobStorageSettings>
            (builderConfiguration.GetSection(BlobStorageSettings.SectionName));
        services.AddSingleton(provider => 
            provider.GetRequiredService<IOptions<BlobStorageSettings>>().Value);
        services.ConfigureBlobClient();
        
        services.AddAuth(builderConfiguration).AddPersistence();
        return services;
    }
    private static void ConfigureBlobClient(this IServiceCollection services)
    {
        services.AddHttpClient<IBlobService, BlobService>((serviceProvider, httpClient) =>
            {
                var blobSettings = serviceProvider.GetRequiredService<IOptions<BlobStorageSettings>>().Value;
                httpClient.BaseAddress = new Uri(blobSettings.BaseAddress);
                httpClient.DefaultRequestHeaders.Add("X-Api-Key", blobSettings.Authorization);
            })
            .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(5)
            })
            .SetHandlerLifetime(Timeout.InfiniteTimeSpan);
    }

    private static void AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<HouseFinder360DbContext>(options => 
            options.UseNpgsql(CreateConnectionString(), o =>
                o.MigrationsAssembly(typeof(HouseFinder360DbContext).Assembly.FullName)
                ).EnableSensitiveDataLogging());
        
        services.AddScoped<IDbContext>(provider => provider.GetRequiredService<HouseFinder360DbContext>());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static string CreateConnectionString()
    {
        var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
        var database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "house-finder";
        var username = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "postgres";
        var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "postgres";
        return $"Server={server};Port={port};Database={database};Username={username};Password={password}";
    }
    private static IServiceCollection AddAuth(this IServiceCollection services,
        IConfiguration builderConfiguration)
    {
        var jwtSettings = new JwtSettings();
        builderConfiguration.Bind(JwtSettings.SectionName,jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => 
                options.TokenValidationParameters = new TokenValidationParameters
            {
              ValidateAudience  = true,
              ValidateIssuer = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = jwtSettings.Issuer,
              ValidAudience = jwtSettings.Audience,
              IssuerSigningKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET") ?? "PFJ52kF3xywSyLK0")
                  )
            });
        return services;
    }
}