using System.Reflection;
using System.Text;
using FluentValidation;
using HouseFinder360.Users.Infrastructure.Common.Interfaces;
using HouseFinder360.Users.Infrastructure.Features.Authentication.Commands.Register;
using HouseFinder360.Users.Infrastructure.Jwt;
using HouseFinder360.Users.Infrastructure.Model;
using HouseFinder360.Users.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HouseFinder360.Users.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddValidation();
        // mediator
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                // .AddBehavior<IPipelineBehavior<RegisterCommand, Result<AuthResult>>, 
                //     ValidationBehaviour<RegisterCommand, AuthResult>>()
        );
        services.AddPersistence();
        services.AddIdentityUser();
        services.AddAuth(configuration);
        return services;
    }
    private static void AddValidation(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterCommand>, RegisterRequestValidator>();
    }
    private static void AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<UserDbContext>(options => 
            options.UseNpgsql(CreateConnectionString(),
                    npgsqlOptions =>
                    {
                        npgsqlOptions.MigrationsHistoryTable(
                            tableName: HistoryRepository.DefaultTableName,
                            schema: Schema.UsersSchema
                        );
                    
                    }
                )
                .UseNpgsql(
                    b => b.MigrationsAssembly(typeof(UserDbContext).Assembly.FullName)
                )
                .EnableSensitiveDataLogging());
    }

    private static void AddIdentityUser(this IServiceCollection services)
    {
        services.AddIdentity<User, UserRole>()
            .AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders();
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
    private static IServiceCollection AddAuth(
        this IServiceCollection services,
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