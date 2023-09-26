FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
RUN apt-get update && apt-get install -y openssl
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HouseFinder360.Api/HouseFinder360.Api.csproj", "HouseFinder360.Api/"]

COPY ["HouseFinder360.RealEstates.Api/HouseFinder360.RealEstates.Api.csproj", "HouseFinder360.RealEstates.Api/"]
COPY ["HouseFinder360.RealEstates.Domain/HouseFinder360.RealEstates.Domain.csproj", "HouseFinder360.RealEstates.Domain/"]
COPY ["HouseFinder360.RealEstates.Application/HouseFinder360.RealEstates.Application.csproj", "HouseFinder360.RealEstates.Application/"]
COPY ["HouseFinder360.RealEstates.Infrastructure/HouseFinder360.RealEstates.Infrastructure.csproj", "HouseFinder360.RealEstates.Infrastructure/"]

COPY ["HouseFinder360.Users.Api/HouseFinder360.Users.Api.csproj", "HouseFinder360.Users.Api/"]
COPY ["HouseFinder360.Users.Infrastructure/HouseFinder360.Users.Infrastructure.csproj", "HouseFinder360.Users.Infrastructure/"]

#COPY ["HouseFinder360.Notifications.Api/HouseFinder360.Notifications.Api.csproj", "HouseFinder360.Notifications.Api/"]
#COPY ["HouseFinder360.Notifications.Infrastructure/HouseFinder360.Notifications.Infrastructure.csproj", "HouseFinder360.Notifications.Infrastructure/"]
#COPY ["HouseFinder360.Notifications.Core/HouseFinder360.Notifications.Core.csproj", "HouseFinder360.Notifications.Core/"]

COPY ["HouseFinder360.Application.BuildingBlocks/HouseFinder360.Application.BuildingBlocks.csproj", "HouseFinder360.Application.BuildingBlocks/"]
COPY ["HouseFinder360.Domain.BuildingBlocks/HouseFinder360.Domain.BuildingBlocks.csproj", "HouseFinder360.Domain.BuildingBlocks/"]

RUN dotnet restore "HouseFinder360.Api/HouseFinder360.Api.csproj"

COPY . .

WORKDIR "/src/HouseFinder360.Api"
RUN dotnet build "HouseFinder360.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HouseFinder360.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HouseFinder360.Api.dll"]
