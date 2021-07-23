using System.Text.Json.Serialization;

namespace Forecaster.Models.OpenWeather.Partial
{
    public class SysData
    {
        [JsonPropertyName("type")] 
        public int Type { get; set; }
        [JsonPropertyName("id")] 
        public int ID { get; set; }
        [JsonPropertyName("country")] 
        public string Country { get; set; }
        [JsonPropertyName("sunrise")] 
        public long Sunrise { get; set; }
        [JsonPropertyName("sunset")] 
        public long Sunset { get; set; }
    }
}