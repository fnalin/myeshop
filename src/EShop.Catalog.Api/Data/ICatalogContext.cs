using EShop.Catalog.Api.Models;
using MongoDB.Driver;

namespace EShop.Catalog.Api.Data;

public interface ICatalogContext {

    IMongoCollection<Product> Products {get;}
}
