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
        // GET: Forecaster/Index
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}