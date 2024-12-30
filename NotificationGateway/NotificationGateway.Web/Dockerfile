#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NotificationGateway/NotificationGateway.Web/NotificationGateway.Web.csproj", "NotificationGateway/NotificationGateway.Web/"]
COPY ["NotificationGateway/NotificationGateway.Application/NotificationGateway.Application.csproj", "NotificationGateway/NotificationGateway.Application/"]
COPY ["NotificationGateway/NotificationGateway.DataStore/NotificationGateway.DataStore.csproj", "NotificationGateway/NotificationGateway.DataStore/"]
COPY ["NotificationGateway/NotificationGateway.Core/NotificationGateway.Core.csproj", "NotificationGateway/NotificationGateway.Core/"]
RUN dotnet restore "./NotificationGateway/NotificationGateway.Web/NotificationGateway.Web.csproj"
COPY . .
WORKDIR "/src/NotificationGateway/NotificationGateway.Web"
RUN dotnet build "./NotificationGateway.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NotificationGateway.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotificationGateway.Web.dll"]