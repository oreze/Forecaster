using System.Collections.Generic;
using System.Text.Json.Serialization;
using Forecaster.Models.Weather.Subclasses;

namespace Forecaster.Models.Weather
{
    public class CityWeather
    {
        [JsonPropertyName("coord")] public Coordinates Coordinates { get; set; }

        [JsonPropertyName("weather")]
        public IEnumerable<Subclasses.Weather> Weather { get; set; }

        [JsonPropertyName("main")] 
        public Main Main { get; set; }

        [JsonPropertyName("visibility")] public int visibility { get; set; }
        [JsonPropertyName("dt")] public long DateTime { get; set; }
    }
}