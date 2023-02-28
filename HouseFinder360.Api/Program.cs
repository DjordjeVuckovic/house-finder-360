using HouseFinder360.Application;
using HouseFinder360.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddSwaggerDocument();
}
var app = builder.Build();
{
    app.UseStaticFiles();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseOpenApi();
    app.UseSwaggerUi3();
    app.Run();
}
