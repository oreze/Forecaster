using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Forecaster.Models.Weather;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Forecaster.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private HttpClient _client { get; }
        private IConfiguration _configuration { get; set; }
        

        public OpenWeatherService(HttpClient client,
            IConfiguration configuration)
        {
            client.BaseAddress = new Uri("http://api.openweathermap.org");
            client.DefaultRequestHeaders.Add("User-Agent", "Asp.Net-Forecaster");

            _client = client;
            _configuration = configuration;
        }
        
        public async Task<IEnumerable<CityWeather>> GetLocationWeather()
        {
            Log.Information(_configuration["Api:OpenWeather:ApiKey"]);
            var response = await _client.GetAsync(
                "/data/2.5/weather?q=London&appid=" + _configuration["Api:OpenWeather:ApiKey"]);
            
            response.EnsureSuccessStatusCode();
            
            using var responseStream = await response.Content.ReadAsStreamAsync();
            Log.Information("XDDDDDDDDDDDDDDDDDDDDDDD");
            return await JsonSerializer.DeserializeAsync<IEnumerable<CityWeather>>(responseStream);
        }
    }
}