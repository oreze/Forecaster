using Forecaster.Models.OpenWeather;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Forecaster.Services
{
    public interface IOpenWeatherHttpService
    {
        public Task<(CityWeather CurrentWeather, HttpStatusCode Code)> GetLocationWeather(string location,
            string units = "metric");
    }
}
