using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _CargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal CargoCustomerDal)
        {
            _CargoCustomerDal = CargoCustomerDal;
        }

        public void TDelete(int id)
        {
            _CargoCustomerDal.Delete(id);
        }

        public List<CargoCustomer> TGetAll()
        {
            return _CargoCustomerDal.GetAll();
        }

        public CargoCustomer TGetById(int id)
        {
            return _CargoCustomerDal.GetById(id);
        }

        public CargoCustomer TGetCargoCustomerByID(string id)
        {
            return _CargoCustomerDal.GetCargoCustomerByID(id);
        }

        public void TInsert(CargoCustomer entity)
        {
            _CargoCustomerDal.Insert(entity);
        }

        public void TUpdate(CargoCustomer entity)
        {
            _CargoCustomerDal.Update(entity);
        }
    }
}
