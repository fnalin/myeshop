using EShop.Catalog.Api.Data;
using EShop.Catalog.Api.Models;
using MongoDB.Driver;

namespace EShop.Catalog.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ICatalogContext _context;

    public ProductRepository(ICatalogContext context)
    {
        _context = context ??
                throw new ArgumentException(nameof(context));
    }

    public async Task CreateProduct(Product product)
    {
        await _context.Products.InsertOneAsync(product);
    }

    public async Task<bool> DeleteProduct(string id)
    {
        FilterDefinition<Product> filter = 
                Builders<Product>.Filter.Eq(p => p.Id, id);
        
        DeleteResult deleteResult = 
            await _context.Products.DeleteOneAsync(filter);
        
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<Product> GetProductById(string id)
    {
        return await _context.Products
                                .Find(p => p.Id == id)
                                .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.Find(p => true).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryName)
    {
        FilterDefinition<Product> filter = 
                Builders<Product>.Filter.Eq(p => p.Category, categoryName);


        return await _context.Products.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByName(string name)
    {
        FilterDefinition<Product> filter = 
                Builders<Product>.Filter.Eq(p => p.Name, name);


        return await _context.Products.Find(filter).ToListAsync();
    }

    public async Task<bool> UpdateProduct(Product product)
    {

        var updateResult = 
            await _context.Products.ReplaceOneAsync(
                filter: g=>g.Id == product.Id,
                replacement : product
            );
        
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }
}