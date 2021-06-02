using System.Diagnostics;
using System.Threading.Tasks;
using Forecaster.Models;
using Forecaster.Models.OpenWeather;
using Forecaster.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Forecaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly OpenWeatherService _openWeather;

        public HomeController(OpenWeatherService openWeather)
        {
            _openWeather = openWeather;
        }

        // GET: Forecaster/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET: Forecaster/Weather
        public async Task<IActionResult> Weather(string location)
        {
            var WeatherTuple = await _openWeather.GetLocationWeather(location);

            return View(WeatherTuple);
        }

        // POST: Forecaster/Index
        [HttpPost]
        public async Task<IActionResult> Index([Bind("Location,Model")]GetWeather weather)
        {
            Log.Information("GetWeather object passed to \"weather/index\" method");
            Log.Information("Mode " + weather.Mode);
            Log.Information("Location " + weather.Location);

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Weather), new {location = weather.Location});
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}