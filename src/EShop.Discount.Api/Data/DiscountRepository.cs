 using System;
using System.Data;
using Dapper;
using EShop.Discount.Api.Models;
using Npgsql;

namespace EShop.Discount.Api.Data
{
	public class DiscountRepository : IDiscountRepository
    {
        private readonly IDbConnection _connSql;

        public DiscountRepository(IConfiguration config)
		{
            var _conn = config.GetConnectionString("DatabaseConn");
            _connSql = new NpgsqlConnection(_conn);
        }

        public async Task<Coupon> GetDiscountAsync(string productName)
        {
            var data = await _connSql
                    .QueryFirstOrDefaultAsync<Coupon>
                        ("SELECT * FROM Coupon WHERE ProductName = @ProductName",
                            new { ProductName = productName });

            return data ??
                    new Coupon {
                        ProductName = "No Discount",
                        Description = "No discount desc"
                    };
        }

        public async Task<bool> CreateDiscountAsync(Coupon coupon)
        {
            var affected = await _connSql.ExecuteAsync(
                    "INSERT INTO Coupon (ProductName, Description, Amount) " +
                        "VALUES (@ProductName, @Description, @Amount)",
                    new {
                        ProductName = coupon.ProductName,
                        Description = coupon.Description,
                        Amount = coupon.Amount
                    }
            );

            return affected > 0;
        }


        public async Task<bool> UpdateDiscountAsync(Coupon coupon)
        {
            var affected = await _connSql.ExecuteAsync(
                     "UPDATE Coupon SET ProductName=@ProductName, " +
                        "Description=@Description, Amount=@Amount " +
                            "WHERE Id=@Id",
                     new
                     {
                         ProductName = coupon.ProductName,
                         Description = coupon.Description,
                         Amount = coupon.Amount,
                         Id = coupon.Id
                     }
             );

            return affected > 0;
        }


        

        public async Task<bool> DeleteDiscountAsync(string productName)
        {
            var affected = await _connSql.ExecuteAsync(
                     "DELETE FROM Coupon WHERE ProductName=@ProductName",
                     new
                     {
                         ProductName = productName
                     }
             );

            return affected > 0;
        }

    }
}

