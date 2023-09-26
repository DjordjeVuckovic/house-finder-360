using DotNetEnv.Configuration;
using HouseFinder360.RealEstates.Application.Common.BlobStorage;
using HouseFinder360.RealEstates.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.RealEstates.Application.Common.Interfaces.Services;
using HouseFinder360.RealEstates.Infrastructure.Common.Blob;
using HouseFinder360.RealEstates.Infrastructure.Persistence;
using HouseFinder360.RealEstates.Infrastructure.Persistence.Generic;
using HouseFinder360.RealEstates.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HouseFinder360.RealEstates.Infrastructure;

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
        services.AddPersistence();
        
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
            options.UseNpgsql(CreateConnectionString(),
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        tableName: HistoryRepository.DefaultTableName,
                        schema: Schema.PropertiesSchema
                    );
                }
                )
                .UseNpgsql(
                    b =>
                    {
                        b.MigrationsAssembly(typeof(HouseFinder360DbContext).Assembly.FullName);
                    })
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());
        
        services.AddScoped<IDbContext>(provider => provider.GetRequiredService<HouseFinder360DbContext>());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static string CreateConnectionString()
    {
        var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
        var database = Environment.GetEnvironmentVariable("DATABASE_DB") ?? "house-finder";
        var username = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "postgres";
        var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "postgres";
        return $"Server={server};Port={port};Database={database};Username={username};Password={password}";
    }
}