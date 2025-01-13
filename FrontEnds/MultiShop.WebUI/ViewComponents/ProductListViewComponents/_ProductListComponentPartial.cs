using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            if (id == null)
            {
                var client1 = _httpClientFactory.CreateClient();
                var responseMessage1 = await client1.GetAsync("https://localhost:7061/api/Products");
                if (responseMessage1.IsSuccessStatusCode)
                {
                    var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                    var values1 = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData1);
                    return View(values1);

                }
                return View();
            }
            else
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7061/api/Products/ProductListWithCategoryByCategoryID?id=" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                    return View(values);

                }
            }
           
            return View();
        }

    }
}
