using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/UserComment")]
    public class UserCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Yorumlar İşlemleri";
            ViewBag.v3 = "Yorum Tablosu";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7036/api/Comments");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);

            }
            return View();
        }


        [Route("DeleteUserComment/{id}")]
        public async Task<IActionResult> DeleteUserComment(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7036/api/Comments?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "UserComment", new { area = "Admin" });

            }

            return View();
        }


        [Route("UpdateUserComment/{id}")]
        public async Task<IActionResult> UpdateUserComment(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Yorumlar İşlemleri";
            ViewBag.v3 = "Yorum Güncelleme İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7036/api/Comments/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
                return View(values);

            }
            return View();
        }

        [Route("UpdateUserComment/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateUserComment(UpdateCommentDto updateUserCommentDto)
        {
            updateUserCommentDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateUserCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7036/api/Comments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "UserComment", new { area = "Admin" });

            }

            return View();
        }
    }
}
