using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Forecaster.Models;
using Forecaster.Models.Weather;
using Forecaster.Services;
using Serilog;

namespace Forecaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OpenWeatherService _openWeather;

        public HomeController(ILogger<HomeController> logger,
            OpenWeatherService openWeather)
        {
            _logger = logger;
            _openWeather = openWeather;
        }

        public async Task<IActionResult> Index()
        {
            var weather = await _openWeather.GetLocationWeather("London");
            Log.Information("weather.Main");
            Log.Debug("weather.Main");
            Log.Warning("weather.Main");
            Log.Fatal("XD");
            return View(weather);
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