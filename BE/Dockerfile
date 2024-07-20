#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
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
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Atriis.BestBuy.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Atriis.BestBuy.API.dll"]