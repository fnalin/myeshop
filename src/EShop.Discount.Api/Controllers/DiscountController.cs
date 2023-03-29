using System;
using EShop.Discount.Api.Data;
using EShop.Discount.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Discount.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DiscountController : ControllerBase
	{
        private readonly ILogger<DiscountController> _logger;
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(
            ILogger<DiscountController> logger,
            IDiscountRepository discountRepository)
        {
            _logger = logger;
            _discountRepository = discountRepository;
        }


        [HttpGet("{productName}", Name = "GetDiscount")]
        public async Task<ActionResult<Coupon>> GetDiscount(string productName) {
            var data = await _discountRepository.GetDiscountAsync(productName);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Coupon>> CreateDiscount([FromBody]Coupon coupon)
        {
            await _discountRepository.CreateDiscountAsync(coupon);
            return CreatedAtRoute("GetDiscount", new { coupon.ProductName }, coupon);
        }

        [HttpPut]
        public async Task<ActionResult<Coupon>> UpdateDiscount([FromBody] Coupon coupon)
        {
            await _discountRepository.UpdateDiscountAsync(coupon);
            return NoContent();
        }

        [HttpDelete("{productName}")]
        public async Task<ActionResult<Coupon>> DeleteDiscount(string productName)
        {
            await _discountRepository.DeleteDiscountAsync(productName);
            return NoContent();
        }

    }
}

