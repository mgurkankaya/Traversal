﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ApiBookingHotelSearch : Controller
    {
        public async Task<IActionResult> Index()
        {
            //using System.Net.Http.Headers;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?dest_id=-1456928&order_by=popularity&checkout_date=2025-01-23&children_number=2&filter_by_currency=EUR&locale=en-gb&dest_type=city&checkin_date=2025-01-19&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&include_adjacency=true&page_number=0&adults_number=2&room_number=1&units=metric"),
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
                var value = JsonConvert.DeserializeObject<ApiBookingHotelSearchViewModel>(body);
                return View(value.results);
            }
        }

        public IActionResult GetCityDestId()
        {
            return View();
        }

            [HttpPost]
        public async Task<IActionResult> GetCityDestId(string p)
        {
            //using System.Net.Http.Headers;
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={p}"),
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
                return View();
            }
        }
    }
}
