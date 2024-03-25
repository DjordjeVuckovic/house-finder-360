using HouseFinder360.RealEstates.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.RealEstates.Api;

public static class RealEstateMigrations
{
    public static void RunRealEstateMigrations(this WebApplication app, IWebHostEnvironment env)
    {
        /*if(env.IsProduction()) return;*/
        using var serviceScope = app.Services.CreateScope();
        var services = serviceScope.ServiceProvider;
        try
        {
            var context = services.GetService<HouseFinder360DbContext>();
            context?.Database.Migrate();
        }
        catch (Exception e)
        {
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<IAssemblyMarker>>();
            logger.LogError(e, "An error occurred while migrating or seeding the database.");
        }
    }
}
