using System.Text.Json.Serialization;

namespace Forecaster.Models.OpenWeather.Partial
{
    public class Clouds
    {
        [JsonPropertyName("all")] public int All { get; set; }
    }
}