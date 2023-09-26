FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
RUN apt-get update && apt-get install -y openssl
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY ./publish .
ENTRYPOINT ["dotnet", "HouseFinder360.Api.dll"]