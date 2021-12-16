using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Forecaster.Models.OpenWeather;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Forecaster.Services
{
    public class OpenWeatherService : IOpenWeatherHttpService
    {
        private HttpClient _client { get; }
        private IConfiguration _configuration { get; set; }
        private readonly IWebHostEnvironment _env;
        private static string OpenWeatherApiUri = "http://api.openweathermap.org";
        private static string OpenWeatherCurrentWeatherUri = "/data/2.5/weather";


        public OpenWeatherService(HttpClient client,
            IConfiguration configuration,
            IWebHostEnvironment env)
        {
            _client = client;
            _configuration = configuration;
            _env = env;

            _client.BaseAddress = new Uri(OpenWeatherApiUri);
            _client.DefaultRequestHeaders.Add("User-Agent", "Asp.Net-Forecaster");
        }

        public async Task<(CityWeather CurrentWeather, HttpStatusCode Code)> GetLocationWeather(string location,
            string units = "metric")
        {
            var requestUri = OpenWeatherCurrentWeatherUri +
                             "?q=" + location +
                             "&units=" + units +
                             "&appid=" + GetApiKey();

            var response = await _client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                await using var responseStream = await response.Content.ReadAsStreamAsync();
                return (await JsonSerializer.DeserializeAsync<CityWeather>(responseStream), response.StatusCode);
            }
            return (new CityWeather(), response.StatusCode);
        }

        public async Task<(CityWeather CurrentWeather, HttpStatusCode Code)> GetGeoLocationWeather(double latitude, 
            double longitude, string units = "metric")
        {
            var requestUri = OpenWeatherCurrentWeatherUri +
                             "?lat=" + latitude +
                             "&lon=" + longitude +
                             "&units=" + units +
                             "&appid=" + GetApiKey();

            var response = await _client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                await using var responseStream = await response.Content.ReadAsStreamAsync();
                return (await JsonSerializer.DeserializeAsync<CityWeather>(responseStream), response.StatusCode);
            }
            return (new CityWeather(), response.StatusCode);
        }

        public async Task<(FiveDaysWeather Weathers, HttpStatusCode Code)> GetFiveDaysWeather(string location, string units = "metric")
        {
            var requestUri = OpenWeatherCurrentWeatherUri +
                             "?q=" + location +
                             "&units=" + units +
                             "&appid=" + GetApiKey();

            var response = await _client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                await using var responseStream = await response.Content.ReadAsStreamAsync();
                return (await JsonSerializer.DeserializeAsync<FiveDaysWeather>(responseStream), response.StatusCode);
            }
            return (new FiveDaysWeather(), response.StatusCode);
        }

        private string GetApiKey()
        {
            if (_env.IsDevelopment())
                return _configuration["Api:OpenWeather"];
            else
                return Environment.GetEnvironmentVariable("OPENWEATHERAPIKEY");
        }
    }
}