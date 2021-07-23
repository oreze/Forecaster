using System.Text.Json.Serialization;

namespace Forecaster.Models.OpenWeather.Partial
{
    public class Weather
    {
        [JsonPropertyName("id")] 
        public int ID { get; set; }
        [JsonPropertyName("main")] 
        public string Main { get; set; }
        [JsonPropertyName("description")] 
        public string Description { get; set; }
        [JsonPropertyName("icon")] 
        public string Icon { get; set; }
    }
}