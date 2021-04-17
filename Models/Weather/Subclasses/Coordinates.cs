using System.Text.Json.Serialization;

namespace Forecaster.Models.Weather.Subclasses
{
    public class Coordinates
    {
        [JsonPropertyName("lon")] public double Longitude  { get; set; }

        [JsonPropertyName("lat")] public double Latitude { get; set; }
    }
}