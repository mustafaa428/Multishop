using Microsoft.AspNetCore.Mvc;
using Multishop.RapidAPIWebUI.Models;
using Newtonsoft.Json;


namespace Multishop.RapidAPIWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> WeatherDetail()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/Adıyaman"),
                Headers =
    {
        { "x-rapidapi-key", "acd0ef3083msh2410e59bfa13bf4p1f139bjsna055dc9a5dbb" },
        { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);
                ViewBag.CityTemp = values.data.temp;
                return View();
            }
        }

        public async Task<IActionResult> Exchange()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
                Headers =
    {
        { "x-rapidapi-key", "acd0ef3083msh2410e59bfa13bf4p1f139bjsna055dc9a5dbb" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeModel.Rootobject>(body);
                ViewBag.Exchange = values.data.exchange_rate;
                ViewBag.previus = values.data.previous_close;
            }
            return View();
        }


    }
}
