FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EShop.Catalog.Api/EShop.Catalog.Api.csproj", "EShop.Catalog.Api/"]
RUN dotnet restore "EShop.Catalog.Api/EShop.Catalog.Api.csproj"
COPY . .
WORKDIR "/src/EShop.Catalog.Api"
RUN dotnet build "EShop.Catalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EShop.Catalog.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EShop.Catalog.Api.dll"]