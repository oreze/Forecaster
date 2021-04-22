using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Forecaster.Models;
using Forecaster.Models.OpenWeather;
using Forecaster.Services;
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
        
        // POST: Forecaster/Index
        [HttpPost]
        public IActionResult Index([Bind("Location,Model")]GetWeather weather)
        {
            Log.Information("GetWeather object passed to \"weather/index\" method");
            Log.Information("Mode " + weather.Mode);
            Log.Information("Location " + weather.Location);
            
            return RedirectToAction("Index", new { Controller = "Weather", Action="Index", location=weather.Location, mode=weather.Mode});
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