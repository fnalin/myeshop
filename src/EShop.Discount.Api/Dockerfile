FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EShop.Discount.Api/EShop.Discount.Api.csproj", "EShop.Discount.Api/"]
RUN dotnet restore "EShop.Discount.Api/EShop.Discount.Api.csproj"
COPY . .
WORKDIR "/src/EShop.Discount.Api"
RUN dotnet build "EShop.Discount.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EShop.Discount.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EShop.Discount.Api.dll"]
