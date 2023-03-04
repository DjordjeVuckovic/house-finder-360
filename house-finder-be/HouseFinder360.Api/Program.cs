using System.Security.Cryptography.X509Certificates;
using HouseFinder360.Api;
using HouseFinder360.Application;
using HouseFinder360.Infrastructure;
using HouseFinder360.Infrastructure.Persistence;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddInfrastructure(builder.Configuration)
        .AddPresentation()
        .AddApplication();
}
var app = builder.Build();
{
    app.RunMigrations();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseOpenApi();
    app.UseSwaggerUi3();
    app.Run();
}
