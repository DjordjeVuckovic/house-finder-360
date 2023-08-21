using HouseFinder360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Api;

public static class RunMigration
{
    public static void RunMigrations(this WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();
        var services = serviceScope.ServiceProvider;
        try
        {
            var context = services.GetService<HouseFinder360DbContext>();
            context?.Database.Migrate();
        }
        catch (Exception e)
        {
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(e, "An error occurred while migrating or seeding the database.");
        }
    }
}