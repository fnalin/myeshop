using System;
namespace EShop.Discount.Api.Models
{
	public class Coupon
	{
		public int Id { get; set; }
		public string ProductName { get; set; } = null!;
		public string? Description { get; set; }
		public int Amount { get; set; }
	}
}

