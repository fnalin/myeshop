using EShop.Catalog.Api.Models;
using MongoDB.Driver;

namespace EShop.Catalog.Api.Data;

public class CatalogContext : ICatalogContext
{
    private readonly IConfiguration config;

    public IMongoCollection<Product> Products {get;}
    
    public CatalogContext(IConfiguration config)
    {
        this.config = config;
        var client = 
            new MongoClient(
                        config.GetValue<string>("DatabaseSettings:ConnectionString")
            );
        var database = client.GetDatabase(
            config.GetValue<string>("DatabaseSettings:DatabaseName")
        );

        Products = database.GetCollection<Product>(
            config.GetValue<string>("DatabaseSettings:CollectionName")

        );

        Products.SeedData();
        
    }
}
