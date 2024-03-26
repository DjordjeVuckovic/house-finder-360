using HouseFinder360.Users.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HouseFinder360.Users.Api;

public static class UsersMigrations
{
    public static void RunUsersMigrations(
        this WebApplication app,
        IWebHostEnvironment webHostEnvironment)
    {
        using var serviceScope = app.Services.CreateScope();
        var services = serviceScope.ServiceProvider;
        try
        {
            var context = services.GetService<UserDbContext>();
            context?.Database.Migrate();
            context?.SeedRoles();
            /*if(webHostEnvironment.IsProduction()) return;*/
        }
        catch (Exception e)
        {
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<IUserApiMarker>>();
            logger.LogError(e, "An error occurred while migrating users the database.");
        }
    }
}
