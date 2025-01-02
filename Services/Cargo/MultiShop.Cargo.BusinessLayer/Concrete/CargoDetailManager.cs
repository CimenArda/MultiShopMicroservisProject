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
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _CargoDetailDal;

        public CargoDetailManager(ICargoDetailDal CargoDetailDal)
        {
            _CargoDetailDal = CargoDetailDal;
        }

        public void TDelete(int id)
        {
            _CargoDetailDal.Delete(id);
        }

        public List<CargoDetail> TGetAll()
        {
            return _CargoDetailDal.GetAll();
        }

        public CargoDetail TGetById(int id)
        {
            return _CargoDetailDal.GetById(id);
        }

        public void TInsert(CargoDetail entity)
        {
            _CargoDetailDal.Insert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            _CargoDetailDal.Update(entity);
        }
    }
}
