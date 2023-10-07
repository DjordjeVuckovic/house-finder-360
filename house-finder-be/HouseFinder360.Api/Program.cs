using HouseFinder360.Api;
using HouseFinder360.Api.Endpoints;
using HouseFinder360.Api.Swagger;
using HouseFinder360.Application.BuildingBlocks;
using HouseFinder360.RealEstates.Api;
using HouseFinder360.RealEstates.Api.Endpoints;
using HouseFinder360.Users.Api;
using HouseFinder360.Users.Api.Endpoints;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

const string policyName = "HouseFinderPolicy";
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>,ConfigureSwaggerOptions>();
    
    builder.Services.AddAuthentication();
    builder.Services.AddAuthorization();

    builder.Services
        .AddBootstrapper()
        .AddRealEstateModule(builder.Configuration)
        .AddUsersModule(builder.Configuration)
        .AddBuildingBlocksApplicationDependencyInjection();
    
    builder.Services
        .AddCors(options =>
        {
            options.AddPolicy(policyName,
                b => b.WithOrigins(builder.Configuration["AllowedHosts"]!)
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()); 
        });
}
var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    if (app.Environment.IsProduction())
    {
        app.UseExceptionHandler("/error");   
    }
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors(policyName);
    
    app.MapErrorsModule()
        .MapRealEstateModule()
        .MapUserModule();
    
    app.UseAuthentication();
    app.UseAuthorization();
    
    app.RunRealEstateMigrations(app.Environment);
    app.RunUsersMigrations(app.Environment);
    
    app.Run();
}
