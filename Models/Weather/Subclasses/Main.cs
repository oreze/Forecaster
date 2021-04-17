﻿using System.Text.Json.Serialization;

namespace Forecaster.Models.Weather.Subclasses
{
    public class Main
    {
        [JsonPropertyName("temp")] 
        public float Temp { get; set; }
        [JsonPropertyName("feels_like")] 
        public float FeelsLike { get; set; }
        [JsonPropertyName("temp_min")] 
        public float TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public float TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public float Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }
}