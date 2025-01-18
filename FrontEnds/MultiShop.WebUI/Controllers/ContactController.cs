using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Nodes;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {

			string token = "";
			using (var httpClient = new HttpClient())
			{
				var request = new HttpRequestMessage
				{
					RequestUri = new Uri("https://localhost:5001/connect/token"),
					Method = HttpMethod.Post,
					Content = new FormUrlEncodedContent(new Dictionary<string, string>
					{
						{"client_id","MultiShopVisitorId" },
						{"client_secret","multishopsecret" },
						{"grant_type","client_credentials" }
					})
				};
				using (var response = await httpClient.SendAsync(request))
				{
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						var tokenResponse = JsonObject.Parse(content);
						token = tokenResponse["access_token"].ToString();
						;
					}
				}
			}



			createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7061/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
