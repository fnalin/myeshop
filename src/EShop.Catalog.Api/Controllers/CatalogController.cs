using EShop.Catalog.Api.Models;
using EShop.Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Catalog.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogController : ControllerBase {
    private readonly IProductRepository _productRepository;
    private readonly ILogger<CatalogController> _logger;

    public CatalogController(
        IProductRepository productRepository,
        ILogger<CatalogController> logger)
    {
        _productRepository = productRepository ?? 
                        throw new ArgumentException(nameof(productRepository));
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>),StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts() {

        var products = await _productRepository.GetProducts();
        return Ok(products);

    }

    [HttpGet("{id:length(24)}", Name = "GetProduct")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Product),StatusCodes.Status200OK)]
    public async Task<ActionResult<Product>> GetProductById(string id) {

        var product = await _productRepository.GetProductById(id);

        if (product is null) {
            return NotFound();
        }
        return Ok(product);

    }

    [HttpGet]
    [Route("[action]/{category}", Name = "GetProductByCategory")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IEnumerable<Product>),StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category) {

        if (category is null) return BadRequest("Invalid category");

        var products = await _productRepository.GetProductsByCategory(category);

        return Ok(products);

    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Product),StatusCodes.Status201Created)]
    public async Task<ActionResult<Product>> CreateProduct([FromBody]Product product) {

        if (product is null) return BadRequest("Invalid product");

        await _productRepository.CreateProduct(product);

        return CreatedAtRoute("GetProduct", new { id = product.Id}, product);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateProduct([FromBody]Product product) {

        if (product is null) return BadRequest("Invalid product");

        await _productRepository.UpdateProduct(product);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteProduct(string id) {


        await _productRepository.DeleteProduct(id);

        return NoContent();
    }

    
}
