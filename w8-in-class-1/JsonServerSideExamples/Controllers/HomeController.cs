using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JsonServerSideExamples.Models;
using System.Net.Http;
using System.Text.Json;

namespace JsonServerSideExamples.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var geoResult = "http://www.geoplugin.net/json.gp?ip=64.17.241.5";
            HttpClient httpClient1 = new HttpClient();
            // Do the actual request and await the response
            var httpResponse = await httpClient1.GetAsync(geoResult);
            // if you do not have a successful status code, it will throw an exception
            httpResponse.EnsureSuccessStatusCode();
            string resultGeo = httpResponse.Content.ReadAsStringAsync().Result;

            JsonDocument jDoc = JsonDocument.Parse(resultGeo);
            JsonElement root = jDoc.RootElement;
            JsonElement geoLatitude = root.GetProperty("geoplugin_latitude");
            GeoPlugin data = JsonSerializer.Deserialize<GeoPlugin>(resultGeo);

            return View("Index", data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
