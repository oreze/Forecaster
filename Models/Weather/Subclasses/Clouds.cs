using System.Text.Json.Serialization;

namespace Forecaster.Models.Weather.Subclasses
{
    public class Clouds
    {
        [JsonPropertyName("all")] public int clouds { get; set; }
    }
}