using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoDetailDto;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _CargoDetailService;

        public CargoDetailController(ICargoDetailService CargoDetailService)
        {
            _CargoDetailService = CargoDetailService;
        }


        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var value = _CargoDetailService.TGetAll();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
               ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
               SenderCustomer = createCargoDetailDto.SenderCustomer,
               CargoCompanyID = createCargoDetailDto.CargoCompanyID,
               Barcode = createCargoDetailDto.Barcode
               
            };
            _CargoDetailService.TInsert(cargoDetail);
            return Ok("Başarıyla Oluşturuldu");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _CargoDetailService.TDelete(id);
            return Ok("Başarıyla Silindi");
        }



        [HttpGet("{id}")]
        public IActionResult GetCargoDetail(int id)
        {
            var value = _CargoDetailService.TGetById(id);
            return Ok(value);

        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoDetailID = updateCargoDetailDto.CargoDetailID,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                CargoCompanyID = updateCargoDetailDto.CargoCompanyID,
                Barcode = updateCargoDetailDto.Barcode
            };
            _CargoDetailService.TUpdate(cargoDetail);
            return Ok("Başarıyla Güncellendi");
        }




    }
}
