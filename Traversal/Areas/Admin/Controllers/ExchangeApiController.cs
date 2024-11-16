using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ExchangeApiController : Controller
    {
        public async Task<IActionResult> Index(decimal? amount) //kullanıcıdan veri girişi için amount değişkeni oluşturdum.
        {
            ApiBookingExchangeNewModel model = new ApiBookingExchangeNewModel();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=en-gb&currency=TRY"),
                Headers =
        {
            { "x-rapidapi-key", "87161e4985mshb4afc7780dd4579p128412jsn60d57f4b0c17" },
            { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
        },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<ApiBookingExchangeNewModel>(body);

                if (model.exchange_rates != null && amount.HasValue)
                {
                    foreach (var rate in model.exchange_rates)
                    {
                        decimal exchangeRate = Convert.ToDecimal(rate.exchange_rate_buy);
                        rate.exchange_calculated_value = amount.Value * exchangeRate;
                    }
                }
            }
            return View(model.exchange_rates);
        }
    }
}