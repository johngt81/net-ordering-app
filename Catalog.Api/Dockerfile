# Start with the official .NET Core SDK image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
# Set the working directory in the container
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copy the project file and restore dependencies
COPY ["Catalog.Api/Catalog.Api.csproj", "Catalog.Api/"]
COPY . .
WORKDIR "/src/Catalog.Api/"
RUN dotnet build "./Catalog.Api/Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:USER

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Catalog.Api.dll" ]