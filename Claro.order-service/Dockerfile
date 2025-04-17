# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["Claro.order-service.csproj", "."]
RUN dotnet restore "Claro.order-service.csproj"

# Copy the rest of the source code into the container
COPY . .

# Publish the application
RUN dotnet publish "Claro.order-service.csproj" -c Release -o /app/publish

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Start the application
ENTRYPOINT ["dotnet", "Claro.order-service.dll"]
