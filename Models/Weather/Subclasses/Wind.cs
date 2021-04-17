using System.Text.Json.Serialization;

namespace Forecaster.Models.Weather.Subclasses
{
    public class Wind
    {
        [JsonPropertyName("speed")] public float Speed { get; set; }
        [JsonPropertyName("deg")] public float Degrees { get; set; }
    }
}