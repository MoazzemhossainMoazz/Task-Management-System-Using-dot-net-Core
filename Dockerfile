# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files
COPY *.sln ./
COPY TaskManagement1/*.csproj ./TaskManagement1/
RUN dotnet restore

# Copy the rest of the source code
COPY TaskManagement1/ ./TaskManagement1/
WORKDIR /src/TaskManagement1

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Use $PORT if provided, default to 8080
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
EXPOSE 8080

ENTRYPOINT ["dotnet", "TaskManagement1.dll"]