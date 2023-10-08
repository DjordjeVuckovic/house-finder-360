using HouseFinder360.Application.BuildingBlocks.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HouseFinder360.Application.BuildingBlocks;

public static class BuildingBlocksApplicationDependencyInjection
{
  public static IServiceCollection AddBuildingBlocksApplicationDependencyInjection(this IServiceCollection services)
  {
   services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
   services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
   services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
   return services;
  }
}