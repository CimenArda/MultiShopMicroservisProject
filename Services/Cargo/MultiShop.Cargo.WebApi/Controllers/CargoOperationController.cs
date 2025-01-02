using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoOperationDto;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _CargoOperationService;

        public CargoOperationController(ICargoOperationService CargoOperationService)
        {
            _CargoOperationService = CargoOperationService;
        }


        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var value = _CargoOperationService.TGetAll();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
               Barcode = createCargoOperationDto.Barcode,
               Description = createCargoOperationDto.Description,
               OperationDate = createCargoOperationDto.OperationDate,
            };
            _CargoOperationService.TInsert(cargoOperation);
            return Ok("Başarıyla Oluşturuldu");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _CargoOperationService.TDelete(id);
            return Ok("Başarıyla Silindi");
        }



        [HttpGet("{id}")]
        public IActionResult GetCargoOperation(int id)
        {
            var value = _CargoOperationService.TGetById(id);
            return Ok(value);

        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                CargoOperationID = updateCargoOperationDto.CargoOperationID,
                OperationDate = updateCargoOperationDto.OperationDate,
                Description = updateCargoOperationDto.Description,
                Barcode = updateCargoOperationDto.Barcode
            };
            _CargoOperationService.TUpdate(cargoOperation);
            return Ok("Başarıyla Güncellendi");
        }




    }
}
