# Use the ASP.NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["Pinot_HealthCenter_Analytics_WebAPI/Pinot_HealthCenter_Analytics_WebAPI.csproj", "Pinot_HealthCenter_Analytics_WebAPI/"]
RUN dotnet restore "Pinot_HealthCenter_Analytics_WebAPI/Pinot_HealthCenter_Analytics_WebAPI.csproj"

# Copy the rest of the source code and build
COPY . .
WORKDIR "/src/Pinot_HealthCenter_Analytics_WebAPI"
RUN dotnet build "Pinot_HealthCenter_Analytics_WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Pinot_HealthCenter_Analytics_WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# Final stage: copy published files and set the entry point
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pinot_HealthCenter_Analytics_WebAPI.dll"]