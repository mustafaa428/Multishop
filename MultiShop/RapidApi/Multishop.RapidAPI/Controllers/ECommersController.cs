using Microsoft.AspNetCore.Mvc;
using Multishop.RapidAPIWebUI.Models;
using Newtonsoft.Json;

namespace Multishop.RapidAPIWebUI.Controllers
{
    public class ECommersController : Controller
    {
        public async Task<IActionResult> ECommersList()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-product-search.p.rapidapi.com/search-light-v2?q=Acer%20Laptop&country=tr&language=en&page=1&limit=10&sort_by=BEST_MATCH&product_condition=ANY&return_filters=false"),
                Headers =
    {
        { "x-rapidapi-key", "acd0ef3083msh2410e59bfa13bf4p1f139bjsna055dc9a5dbb" },
        { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<ECommersViewModel.Rootobject>(body);
                var values = root.data.products.ToList();
                return View(values);
            }
        }
    }
}
