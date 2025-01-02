using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCompanyDto;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }


        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var value  = _cargoCompanyService.TGetAll();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Başarıyla Oluşturuldu");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Başarıyla Silindi");
        }



        [HttpGet("{id}")]
        public IActionResult GetCargoCompany(int id)
        {
             var value = _cargoCompanyService.TGetById(id);
            return Ok(value);

        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyID = updateCargoCompanyDto.CargoCompanyID,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Başarıyla Güncellendi");
        }












    }
}
