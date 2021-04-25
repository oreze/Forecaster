﻿using System.Net;
using System.Threading.Tasks;
using Forecaster.Models.OpenWeather;
using Forecaster.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Forecaster.Controllers
{
    public class WeatherController : Controller
    {
        private readonly OpenWeatherService _openWeather;

        public WeatherController(OpenWeatherService openWeather)
        {
            _openWeather = openWeather;
        }

        // GET: Forecaster/Index
        public async Task<IActionResult> Index(string location, string mode)
        {
            var WeatherTuple = await _openWeather.GetLocationWeather(location);
            
            return View(WeatherTuple);
        }
    }
}