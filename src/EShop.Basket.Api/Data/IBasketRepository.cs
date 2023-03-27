using System;
using EShop.Basket.Api.Models;

namespace EShop.Basket.Api.Data
{
    public interface IBasketRepository
	{
		Task<ShoppingCart?> GetBasketAsync(string userName);
		Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket);
		Task DeleteBasketAsync(string userName);
	}
}

