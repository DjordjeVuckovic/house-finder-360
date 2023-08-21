using Carter;
using HouseFinder360.Api;
using HouseFinder360.Api.Swagger;
using HouseFinder360.Application;
using HouseFinder360.Infrastructure;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

const string policyName = "HoseFinderPolicy";
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>,ConfigureSwaggerOptions>();
    builder.Services.AddCarter();
    builder.Services.AddAuthentication();
    builder.Services.AddAuthorization();
    builder.Services
        .AddPresentation()
        .AddInfrastructure(builder.Configuration)
        .AddApplication();
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
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors(policyName);
    app.MapCarter();
    app.UseAuthentication();
    app.UseAuthorization();
    app.RunMigrations();
    app.Run();
}
