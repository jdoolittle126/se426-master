using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using w8_in_class_1.Models;

namespace w8_in_class_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new WeatherModel() {LocalDate = "", Location = "", Parameter = "", Unit = "", Value = ""});
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(WeatherModel weatherModel)
        {

            try
            {
                HttpClient httpClient = new HttpClient();
                string url = "https://api.openaq.org/v1/measurements?city=Providence-New%20Bedford-Fall%20River&location=" + weatherModel.Location + "&limit=1";
                var httpResponse = await httpClient.GetAsync(url);
                httpResponse.EnsureSuccessStatusCode();
                string resultString = httpResponse.Content.ReadAsStringAsync().Result;

                JsonDocument jsonDocument = JsonDocument.Parse(resultString);
                JsonElement root = jsonDocument.RootElement.GetProperty("results");

                var model = new WeatherModel();

                foreach (var element in root.EnumerateArray())
                {
                    //Narragansett
                    model.LocalDate = element.GetProperty("date").GetProperty("local").GetString();
                    model.Parameter = element.GetProperty("parameter").GetString();
                    model.Value = element.GetProperty("value").GetRawText();
                    model.Unit = element.GetProperty("unit").GetString();
                    model.Location = element.GetProperty("location").GetString();

                }

                return View(model);


            }
            catch (Exception e)
            {

            }

            return View(new WeatherModel() { LocalDate = "", Location = "", Parameter = "", Unit = "", Value = "" });
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
