using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Basket.Api.Data;
using EShop.Basket.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShop.Basket.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {

        private readonly IBasketRepository _basketRepository;
        private readonly ILogger<BasketController> _logger;

        public BasketController(IBasketRepository basketRepository,
            ILogger<BasketController> logger)
        {
            _basketRepository = basketRepository;
            _logger = logger;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName) {
            var basket = await _basketRepository.GetBasketAsync(userName);

            return Ok(basket ?? new ShoppingCart(userName));
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> GetBasket(ShoppingCart basket)
        {
            var data = await _basketRepository.UpdateBasketAsync(basket);
            return Ok(data);
        }

        [HttpDelete("{userName}")]
        public async Task<ActionResult<ShoppingCart>> DeleteBasket(string userName)
        {
            await _basketRepository.DeleteBasketAsync(userName);
            return NoContent();
        }

    }
}

