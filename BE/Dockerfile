# Use the ASP.NET runtime image as the base for the final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7192 

# Use the .NET SDK image as the base for the build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["Atriis.BestBuy.API/Atriis.BestBuy.API.csproj", "Atriis.BestBuy.API/"]
COPY ["BestBuy.Abstractions/BestBuy.Abstractions.csproj", "BestBuy.Abstractions/"]
COPY ["BestBuy.Core/BestBuy.Core.csproj", "BestBuy.Core/"]
COPY ["BestBuy.EFCore/BestBuy.EFCore.csproj", "BestBuy.EFCore/"]
COPY ["BestBuy.ExternalAPI.Service/BestBuy.ExternalAPI.Service.csproj", "BestBuy.ExternalAPI.Service/"]
RUN dotnet restore "./Atriis.BestBuy.API/Atriis.BestBuy.API.csproj"
COPY . .
WORKDIR "/src/Atriis.BestBuy.API"
RUN dotnet build "./Atriis.BestBuy.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./Atriis.BestBuy.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Use the base image for the final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://localhost:7192 
ENTRYPOINT ["dotnet", "Atriis.BestBuy.API.dll"]
