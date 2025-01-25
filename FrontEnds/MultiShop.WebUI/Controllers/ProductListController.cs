using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(string id)
        {
          
            ViewBag.i = id;
            return View();
        }



        public IActionResult ProductDetail(string id)
        {
            ViewBag.x = id;
            return View();
        }

        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            if (ModelState.IsValid)
            {
                createCommentDto.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/99/Sample_User_Icon.png";
                createCommentDto.CreatedDate = DateTime.Now;
                createCommentDto.Rating = 3; // Varsayılan bir değer
                createCommentDto.Status = false;

                // Gelen ProductID'yi kontrol et
                if (string.IsNullOrEmpty(createCommentDto.ProductID))
                {
                    // Hata durumunda uygun bir yanıt ver
                    ModelState.AddModelError("", "ProductID geçerli değil.");
                    return View();
                }

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createCommentDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7036/api/Comments", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductDetail", new { id = createCommentDto.ProductID });
                }
            }
            return View();
        }

    }
}
