
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ControlGo.API/ControlGo.API.csproj", "ControlGo.API/"]
COPY ["ControlGo.Application/ControlGo.Application.csproj", "ControlGo.Application/"]
COPY ["ControlGo.Infrastructure/ControlGo.Infrastructure.csproj", "ControlGo.Infrastructure/"]
COPY ["ControlGo.Domain/ControlGo.Domain.csproj", "ControlGo.Domain/"]
COPY ["ControlGo.Infrastructure.Bootstrap/ControlGo.Infrastructure.Bootstrap.csproj", "ControlGo.Infrastructure.Bootstrap/"]
RUN dotnet restore "./ControlGo.API/./ControlGo.API.csproj"
COPY . .
WORKDIR "/src/ControlGo.API"
RUN dotnet build "./ControlGo.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ControlGo.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ControlGo.API.dll"]
