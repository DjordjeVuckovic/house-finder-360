using Carter;
using HouseFinder360.Api;
using HouseFinder360.Application;
using HouseFinder360.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCarter();
    builder.Services.AddAuthentication();
    builder.Services.AddAuthorization();
    builder.Services
        .AddPresentation()
        .AddInfrastructure(builder.Configuration)
        .AddApplication();
}
var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.RunMigrations();
    app.UseExceptionHandler("/error");
    app.UseRouting();
    app.UseHttpsRedirection();
    app.MapCarter();
    app.UseAuthentication();
    app.UseAuthorization();
    app.Run();
}
