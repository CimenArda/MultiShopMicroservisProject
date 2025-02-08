using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCustomerDto;
using MultiShop.Cargo.EntityLayer.Entities;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _CargoCustomerService;

        public CargoCustomerController(ICargoCustomerService CargoCustomerService)
        {
            _CargoCustomerService = CargoCustomerService;
        }


        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var value = _CargoCustomerService.TGetAll();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer CargoCustomer = new CargoCustomer()
            {
              Address = createCargoCustomerDto.Address,
              City = createCargoCustomerDto.City,
              District = createCargoCustomerDto.District,
              Email = createCargoCustomerDto.Email,
              Name = createCargoCustomerDto.Name,
              Phone = createCargoCustomerDto.Phone,
              Surname = createCargoCustomerDto.Surname,
              UserCustomerID=createCargoCustomerDto.UserCustomerID
            };
            _CargoCustomerService.TInsert(CargoCustomer);
            return Ok("Başarıyla Oluşturuldu");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _CargoCustomerService.TDelete(id);
            return Ok("Başarıyla Silindi");
        }



        [HttpGet("{id}")]
        public IActionResult GetCargoCustomer(int id)
        {
            var value = _CargoCustomerService.TGetById(id);
            return Ok(value);

        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer CargoCustomer = new CargoCustomer()
            {
                CargoCustomerID = updateCargoCustomerDto.CargoCustomerID,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                Phone = updateCargoCustomerDto.Phone,
                Surname = updateCargoCustomerDto.Surname,
                UserCustomerID=updateCargoCustomerDto.UserCustomerID
            };
            _CargoCustomerService.TUpdate(CargoCustomer);
            return Ok("Başarıyla Güncellendi");
        }


        [HttpGet("GetCargoCustomerByID")]
        public IActionResult GetCargoCustomerByID(string id)
        {
            return Ok(_CargoCustomerService.TGetCargoCustomerByID(id));
        }




    }
}
