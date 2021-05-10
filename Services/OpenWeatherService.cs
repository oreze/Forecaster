using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Forecaster.Models.OpenWeather;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Forecaster.Services
{
    public class OpenWeatherService
    {
        private HttpClient _client { get; }
        private IConfiguration _configuration { get; set; }
        private readonly IWebHostEnvironment _env;
        

        public OpenWeatherService(HttpClient client,
            IConfiguration configuration,
            IWebHostEnvironment env)
        {
            client.BaseAddress = new Uri("http://api.openweathermap.org");
            client.DefaultRequestHeaders.Add("User-Agent", "Asp.Net-Forecaster");

            _client = client;
            _configuration = configuration;
            _env = env;
        }
        
        public async Task<(CityWeather CurrentWeather, HttpStatusCode Code)> GetLocationWeather(string location, string units="metric")
        {
            var requestUri = "/data/2.5/" +
                             "weather?q=" + location +
                             "&units=" + units +
                             "&appid=" + GetApiKey();
            
            var response = await _client.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    return (await JsonSerializer.DeserializeAsync<CityWeather>(responseStream), response.StatusCode);
                }
                else
                {
                    return (new CityWeather(), response.StatusCode);
                }
        }

        private string GetApiKey()
        {
            if (_env.IsDevelopment())
                return _configuration["Api:OpenWeather:ApiKey"];
            else
                return Environment.GetEnvironmentVariable("OPENWEATHERAPIKEY");

        }
    }
}