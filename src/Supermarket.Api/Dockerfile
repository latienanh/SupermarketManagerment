#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000	
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Supermarket.Api/Supermarket.Api.csproj", "src/Supermarket.Api/"]
COPY ["src/Core/Supermarket.Application/Supermarket.Application.csproj", "src/Core/Supermarket.Application/"]
COPY ["src/Core/Supermarket.Domain/Supermarket.Domain.csproj", "src/Core/Supermarket.Domain/"]
COPY ["src/External/Supermaket.Presentation/Supermarket.Presentation.csproj", "src/External/Supermaket.Presentation/"]
COPY ["src/External/Supermarket.Infrastructure/Supermarket.Infrastructure.csproj", "src/External/Supermarket.Infrastructure/"]
RUN dotnet restore "./src/Supermarket.Api/./Supermarket.Api.csproj"
COPY . .
WORKDIR "/src/src/Supermarket.Api"
RUN dotnet build "./Supermarket.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Supermarket.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Supermarket.Api.dll"]