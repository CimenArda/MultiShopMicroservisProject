using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApiUI.Models;
using Newtonsoft.Json;

namespace MultiShop.RapidApiUI.Controllers
{
    public class ECommerceController : Controller
    {
        public async Task<IActionResult> ECommerceList(string product)
        {
            if (string.IsNullOrWhiteSpace(product))
            {
                return View(new List<ECommerceViewModel.Product>());
            }
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://real-time-product-search.p.rapidapi.com/search?q={product}&country=TR&language=en&page=1&limit=10&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"),
                Headers =
    {
        { "x-rapidapi-key", "346952ad39msh7c6fa779b7c03ccp1d1f3ajsnaf29fa8a1e4e" },
        { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ECommerceViewModel>(body);
                return View(values?.data?.products != null ? values.data.products.ToList() : new List<ECommerceViewModel.Product>());
            }
        }
    }
}
