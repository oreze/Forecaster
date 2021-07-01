using System.Collections.Generic;
using System.Text.Json.Serialization;
using Forecaster.Models.OpenWeather.Partial;
using Newtonsoft.Json;

namespace Forecaster.Models.OpenWeather
{
    public class FiveDaysWeather
    {
        [JsonPropertyName("cnt")] public int Count { get; set; }
        [JsonPropertyName("list")] public IEnumerable<CityWeather> Weathers { get; set; }
        [JsonPropertyName("id")] public int ID { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("coord")] public Coordinates Coordinates { get; set; }
        [JsonPropertyName("country")] public string Country { get; set; }
        [JsonPropertyName("population")] public int Population { get; set; }
        [JsonPropertyName("timezone")] public int Timezone { get; set; }
        [JsonPropertyName("sunrise")] public long Sunrise { get; set; }
        [JsonPropertyName("sunset")] public long Sunset { get; set; }
    }
}