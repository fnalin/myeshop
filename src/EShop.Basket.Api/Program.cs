using EShop.Basket.Api.Data;
using EShop.Basket.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cacheSettings = builder.Configuration.GetSection("CacheSettings");
var conn = cacheSettings.Get<CacheSettings>().ConnectionString;
builder.Services.AddStackExchangeRedisCache(options=> {
    options.Configuration = conn;
});

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();

