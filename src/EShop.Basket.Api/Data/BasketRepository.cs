using System.Text.Json;
using EShop.Basket.Api.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace EShop.Basket.Api.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }


        public async Task<ShoppingCart?> GetBasketAsync(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);

            if (string.IsNullOrEmpty(basket))
                return null;

            var data = JsonSerializer.Deserialize<ShoppingCart>(basket);

            return data;
        }
            
        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket)
        {
            await _redisCache.SetStringAsync(
                    basket.UserName,
                    JsonSerializer.Serialize(basket)
                    );
            return await GetBasketAsync(basket.UserName);
        }


        public async Task DeleteBasketAsync(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }
    }
}

