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
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _CargoOperationDal;

        public CargoOperationManager(ICargoOperationDal CargoOperationDal)
        {
            _CargoOperationDal = CargoOperationDal;
        }

        public void TDelete(int id)
        {
            _CargoOperationDal.Delete(id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _CargoOperationDal.GetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return _CargoOperationDal.GetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
            _CargoOperationDal.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            _CargoOperationDal.Update(entity);
        }
    }
}
