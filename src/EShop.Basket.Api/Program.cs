using EShop.Basket.Api.Data;
using EShop.Basket.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cacheSettings = builder.Configuration.GetSection("CacheSettings");
var conn = cacheSettings.Get<CacheSettings>()?.ConnectionString;
builder.Services.AddStackExchangeRedisCache(options=> {
    options.Configuration = conn;// ?? "localhost:6379";
});



var app = builder.Build();

// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.MapControllers();
app.Run();