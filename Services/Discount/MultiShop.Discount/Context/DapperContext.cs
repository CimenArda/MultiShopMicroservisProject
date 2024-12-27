using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
    public class DapperContext :DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _ConnectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ARDACIMEN\\SQLEXPRESS; Initial Catalog=MultiShopDiscountDb; integrated Security=true;");
        }

        public DbSet<Coupon> Coupones { get; set;}
        public IDbConnection CreateConnection() => new SqlConnection(_ConnectionString);






    }
}
