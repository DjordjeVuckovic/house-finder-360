using HouseFinder360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Api;

public static class AddMigration
{
    public static WebApplication RunMigrations(this WebApplication app)
    {
        using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetService<HouseFinder360DbContext>();
        context?.Database.Migrate();
        return app;
    }
}