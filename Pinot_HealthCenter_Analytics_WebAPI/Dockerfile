# Use the appropriate base image for ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the appropriate SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Pinot_HealthCenter_Analytics_WebAPI.csproj", "Pinot_HealthCenter_Analytics_WebAPI/"]
RUN dotnet restore "Pinot_HealthCenter_Analytics_WebAPI/Pinot_HealthCenter_Analytics_WebAPI.csproj"
COPY . .
WORKDIR "/src/Pinot_HealthCenter_Analytics_WebAPI"
RUN dotnet build "Pinot_HealthCenter_Analytics_WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pinot_HealthCenter_Analytics_WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pinot_HealthCenter_Analytics_WebAPI.dll"]
