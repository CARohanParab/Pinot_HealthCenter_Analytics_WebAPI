# Use the SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies (use .csproj for the project name)
COPY *.csproj ./
Run dotnet restore

## Copy the rest of the source code
#COPY . .

# Publish the application
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out ./

#Expose the port your application run on
EXPOSE 80

#Start the application
ENTRYPOINT ["dotnet", "Pinot_HealthCenter_Analytics_WebAPI.dll"]
