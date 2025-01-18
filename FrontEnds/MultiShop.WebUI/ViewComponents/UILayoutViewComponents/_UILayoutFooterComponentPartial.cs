using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutFooterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
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






			var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7061/api/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);

            }
            return View();
        }

    }
}
