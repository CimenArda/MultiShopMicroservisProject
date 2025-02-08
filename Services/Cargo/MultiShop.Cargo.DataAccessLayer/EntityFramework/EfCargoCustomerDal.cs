using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Context;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _context;
        public EfCargoCustomerDal(CargoContext context, CargoContext cargocontext) : base(context)
        {
            _context = cargocontext;
        }

        public CargoCustomer GetCargoCustomerByID(string id)
        {
          var values =  _context.CargoCustomers.Where(x => x.UserCustomerID == id).FirstOrDefault();
            return values;
        }
    }
}
