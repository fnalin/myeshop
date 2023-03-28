FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EShop.Basket.Api/EShop.Basket.Api.csproj", "EShop.Basket.Api/"]
RUN dotnet restore "EShop.Basket.Api/EShop.Basket.Api.csproj"
COPY . .
WORKDIR "/src/EShop.Basket.Api"
RUN dotnet build "EShop.Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EShop.Basket.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "EShop.Basket.Api.dll", "--environment=Development"]
ENTRYPOINT ["dotnet", "EShop.Basket.Api.dll"]
