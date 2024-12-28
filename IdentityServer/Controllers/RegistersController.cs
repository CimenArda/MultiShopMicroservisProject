using IdentityServer.Dtos;
using IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto registerDto)
        {
            var value = new ApplicationUser()
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                UserName = registerDto.UserName,
                Surame = registerDto.Surame
            };
            var result = await _userManager.CreateAsync(value,registerDto.Password);
            if (result.Succeeded)
            {
                return Ok("Başarıyla Eklendi");
            }
            return Ok("Hata var Tekrar Deneyin");
        }










    }
}
