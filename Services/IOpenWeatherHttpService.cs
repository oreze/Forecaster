using Forecaster.Models.OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Forecaster.Services
{
    public interface IOpenWeatherHttpService
    {
        public Task<(CityWeather CurrentWeather, HttpStatusCode Code)> GetLocationWeather(string location,
            string units = "metric");
    }
}
