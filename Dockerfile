FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HouseFinder360.Api/HouseFinder360.Api.csproj", "HouseFinder360.Api/"]
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
