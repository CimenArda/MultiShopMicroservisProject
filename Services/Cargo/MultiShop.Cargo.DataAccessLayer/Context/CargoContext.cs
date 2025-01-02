using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Context
{
    public class CargoContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441;Initial Catalog=MultiShopCargoDb;User=sa;Password=123456Aa*");

        }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }


    }
}
