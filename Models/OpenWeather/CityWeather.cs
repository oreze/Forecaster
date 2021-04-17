using System.Collections.Generic;
using System.Text.Json.Serialization;
using Forecaster.Models.OpenWeather.Partial;
using Forecaster.Models.OpenWeather.Partial;

namespace Forecaster.Models.OpenWeather
{
    public class CityWeather
    {
        [JsonPropertyName("coord")] public Coordinates Coordinates { get; set; }
        [JsonPropertyName("weather")] public IEnumerable<Weather> Weather { get; set; }
        [JsonPropertyName("base")] public string Base { get; set; }
        [JsonPropertyName("main")] public Main Main { get; set; }
        [JsonPropertyName("visibility")] public int Visibility { get; set; }
        [JsonPropertyName("wind")] public Wind Wind { get; set; }
        [JsonPropertyName("clouds")] public Clouds Clouds { get; set; }
        [JsonPropertyName("dt")] public long DateTime { get; set; }
        [JsonPropertyName("sys")] public SysData SysData { get; set; }
        [JsonPropertyName("id")] public int ID { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
    }
}