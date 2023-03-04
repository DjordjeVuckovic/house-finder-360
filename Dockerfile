FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
RUN apt-get update && apt-get install -y openssl
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HouseFinder360.Api/HouseFinder360.Api.csproj", "HouseFinder360.Api/"]
COPY ["HouseFinder360.Domain/HouseFinder360.Domain.csproj", "HouseFinder360.Domain/"]
COPY ["HouseFinder360.Application/HouseFinder360.Application.csproj", "HouseFinder360.Application/"]
COPY ["HouseFinder360.Infrastructure/HouseFinder360.Infrastructure.csproj", "HouseFinder360.Infrastructure/"]
RUN dotnet restore "HouseFinder360.Api/HouseFinder360.Api.csproj"  \
    && dotnet restore "HouseFinder360.Domain/HouseFinder360.Domain.csproj" \
    && dotnet restore "HouseFinder360.Application/HouseFinder360.Application.csproj" \
    && dotnet restore "HouseFinder360.Infrastructure/HouseFinder360.Infrastructure.csproj"
COPY . .
WORKDIR "/src/HouseFinder360.Api"
RUN dotnet build "HouseFinder360.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HouseFinder360.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HouseFinder360.Api.dll"]
