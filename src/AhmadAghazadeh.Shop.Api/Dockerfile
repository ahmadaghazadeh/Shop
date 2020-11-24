#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

WORKDIR /src
COPY ["AhmadAghazadeh.Shop.Api/AhmadAghazadeh.Shop.Api.csproj", "AhmadAghazadeh.Shop.Api/"]
COPY ["AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.DependencyInjection/AhmadAghazadeh.Framework.DependencyInjection.csproj", "AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.DependencyInjection/"]
COPY ["AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.Persistence/AhmadAghazadeh.Framework.Persistence.csproj", "AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.Persistence/"]
COPY ["AhmadAghazadeh.Framework/Ahmad.Aghazadeh.Framework.Core/AhmadAghazadeh.Framework.Core.csproj", "AhmadAghazadeh.Framework/Ahmad.Aghazadeh.Framework.Core/"]
COPY ["AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.Domain/AhmadAghazadeh.Framework.Domain.csproj", "AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.Domain/"]
COPY ["AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.Application/AhmadAghazadeh.Framework.Application.csproj", "AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.Application/"]
COPY ["AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.EventBus/AhmadAghazadeh.Framework.EventBus.csproj", "AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.EventBus/"]
COPY ["AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.Security/AhmadAghazadeh.Framework.Security.csproj", "AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.Security/"]
COPY ["AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.AssemblyHelper/AhmadAghazadeh.Framework.AssemblyHelper.csproj", "AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.AssemblyHelper/"]
COPY ["AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.Facade/AhmadAghazadeh.Framework.Facade.csproj", "AhmadAghazadeh.Framework/AhmadAghazadeh.Framework.Facade/"]
COPY ["AhmadAghazadeh.Shop.ReadModel/AhmadAghazadeh.Shop.ReadModel.Database/AhmadAghazadeh.Shop.ReadModel.Database.csproj", "AhmadAghazadeh.Shop.ReadModel/AhmadAghazadeh.Shop.ReadModel.Database/"]
COPY ["AhmadAghazadeh.Shop.OrderContext/AhmadAghazadeh.Shop.OrderContext.Facade.Contracts/AhmadAghazadeh.Shop.OrderContext.Facade.Contracts.csproj", "AhmadAghazadeh.Shop.OrderContext/AhmadAghazadeh.Shop.OrderContext.Facade.Contracts/"]
COPY ["AhmadAghazadeh.Shop.OrderContext/AhmadAghazadeh.Shop.OrderContext.Application.Contracts/AhmadAghazadeh.Shop.OrderContext.Application.Contracts.csproj", "AhmadAghazadeh.Shop.OrderContext/AhmadAghazadeh.Shop.OrderContext.Application.Contracts/"]
COPY ["AhmadAghazadeh.Shop.Persistence/AhmadAghazadeh.Shop.Persistence/AhmadAghazadeh.Shop.Persistence.csproj", "AhmadAghazadeh.Shop.Persistence/AhmadAghazadeh.Shop.Persistence/"]
COPY ["Ahmad.Aghazadeh.Shop.CustomerContext/AhmadAghazadeh.Shop.CustomerContext.Facade.Contracts/AhmadAghazadeh.Shop.CustomerContext.Facade.Contracts.csproj", "Ahmad.Aghazadeh.Shop.CustomerContext/AhmadAghazadeh.Shop.CustomerContext.Facade.Contracts/"]
COPY ["Ahmad.Aghazadeh.Shop.CustomerContext/AhmadAghazadeh.Shop.CustomerContext.Application.Contracts/AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.csproj", "Ahmad.Aghazadeh.Shop.CustomerContext/AhmadAghazadeh.Shop.CustomerContext.Application.Contracts/"]
RUN dotnet restore "AhmadAghazadeh.Shop.Api/AhmadAghazadeh.Shop.Api.csproj"
COPY . .
WORKDIR "/src/AhmadAghazadeh.Shop.Api"
RUN dotnet build "AhmadAghazadeh.Shop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AhmadAghazadeh.Shop.Api.csproj" -c Release -o /app/publish

FROM base AS final

USER ContainerAdministrator
RUN net localgroup administrators /add "User Manager\ContainerUser"
USER ContainerUser

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AhmadAghazadeh.Shop.Api.dll"]