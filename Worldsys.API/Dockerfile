
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Worldsys.API/Worldsys.API.csproj", "Worldsys.API/"]
COPY ["Worldsys.Application/Worldsys.Application.csproj", "Worldsys.Application/"]
COPY ["Worldsys.Infrastructure/Worldsys.Infrastructure.csproj", "Worldsys.Infrastructure/"]
COPY ["Worldsys.Domain/Worldsys.Domain.csproj", "Worldsys.Domain/"]
COPY ["Worldsys.Infrastructure.Bootstrap/Worldsys.Infrastructure.Bootstrap.csproj", "Worldsys.Infrastructure.Bootstrap/"]
RUN dotnet restore "./Worldsys.API/./Worldsys.API.csproj"
COPY . .
WORKDIR "/src/Worldsys.API"
RUN dotnet build "./Worldsys.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Worldsys.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Worldsys.API.dll"]