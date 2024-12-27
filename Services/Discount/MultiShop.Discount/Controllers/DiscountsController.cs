using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos.CouponDtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _DiscountService;

        public DiscountsController(IDiscountService DiscountService)
        {
            _DiscountService = DiscountService;
        }


        [HttpGet]
        public async Task<IActionResult> CouponListAsync()
        {
            var values = await _DiscountService.GetAllCouponAsync();
            return Ok(values);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponByIdAsync(int id)
        {
            var value = await _DiscountService.GetByIdCouponAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            await _DiscountService.CreateCouponAsync(createCouponDto);
            return Ok("Ekleme İşlemi Tamamlandı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCouponAsync(int id)
        {
            await _DiscountService.DeleteCouponAsync(id);
            return Ok("Silme İşlemi Tamamlandı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            await _DiscountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Güncelleme İşlemi Tamamlandı");
        }
    }
}
