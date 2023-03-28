using System;
using EShop.Discount.Api.Models;

namespace EShop.Discount.Api.Data
{
	public class DiscountRepository : IDiscountRepository
    {
		public DiscountRepository()
		{
		}

        public Task<Coupon> GetDiscountAsync(string productName)
        {
            throw new NotImplementedException();
        }


        public Task<bool> UpdateDiscountAsync(Coupon coupon)
        {
            throw new NotImplementedException();
        }


        public Task<bool> CreateDiscountAsync(Coupon coupon)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDiscountAsync(string productName)
        {
            throw new NotImplementedException();
        }

    }
}

