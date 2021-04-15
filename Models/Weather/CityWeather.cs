using System.Text.Json.Serialization;

namespace Forecaster.Models.Weather
{
    public class CityWeather
    {
        [JsonPropertyName("weather__main")] 
        public string Main { get; set; }
    }
}