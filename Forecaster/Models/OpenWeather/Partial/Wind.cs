using System.Text.Json.Serialization;

namespace Forecaster.Models.OpenWeather.Partial
{
    public class Wind
    {
        [JsonPropertyName("speed")]
        public float Speed { get; set; }
        [JsonPropertyName("deg")]
        public float Degrees { get; set; }
    }
}