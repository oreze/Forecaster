using System;
using System.Linq;
using Forecaster.Models.Enums;
using Forecaster.Models.OpenWeather;
using Forecaster.Models.OpenWeather.Partial;
using Serilog;

namespace Forecaster.Services
{
    public static class CoordinatesHelper
    {
        public static string GetCoordsDirections(this Coordinates coords, bool getLongitude)
        {
            if (getLongitude)
            {
                string LongitudeDirection;

                if (coords.Longitude > 0)
                    LongitudeDirection = coords.Longitude + "° E";
                else if (coords.Longitude < 0)
                    LongitudeDirection = Math.Abs(coords.Longitude) + "° W";
                else
                    LongitudeDirection = coords.Longitude + "°";

                return LongitudeDirection;
            }
            else
            {
                string LatitudeDirection;

                if (coords.Latitude > 0)
                    LatitudeDirection = coords.Latitude + "° N";
                else if (coords.Latitude < 0)
                    LatitudeDirection = Math.Abs(coords.Latitude) + "° S";
                else
                    LatitudeDirection = coords.Latitude + "°";

                return LatitudeDirection;
            }
        }
        
        public static string GetCountry(this CityWeather data)
        {
            Log.Information("Looking for " + data.SysData.Country + " short name");
            foreach (Countries value in Enum.GetValues(typeof(Countries)))
            {
                var FoundedShortName = value.GetShortNameName();
                if (FoundedShortName.Equals(data.SysData.Country.ToUpper()))
                    return value.GetDisplayName();
            }
            return null;
        }

        public static string GetIconSourceUri(this CityWeather weather, bool doubleSized)
        {
            string Uri = "http://openweathermap.org/img/wn/" + weather.Weather.First()?.Icon;
            if (doubleSized)
                Uri += "@2x";
            Uri += ".png";
            return Uri;
        }

        public static string GetFormattedTemperature(this CityWeather weather)
        {
            return Math.Round(weather.Main.Temp, 1)
                .ToString()
                .Replace(",", ".") 
                   + "°C";
        }
        public static string GetFormattedMinTemperature(this CityWeather weather)
        {
            return Math.Round(weather.Main.TempMin, 1)
                .ToString()
                .Replace(",", ".") 
                   + "°C";
        }
        public static string GetFormattedMaxTemperature(this CityWeather weather)
        {
            return Math.Round(weather.Main.TempMax, 1)
                .ToString()
                .Replace(",", ".") 
                   + "°C";
        }
        public static string GetFormattedFeelsLikeTemperature(this CityWeather weather)
        {
            return Math.Round(weather.Main.FeelsLike, 1)
                .ToString()
                .Replace(",", ".") 
                   + "°C";
        }
    }
}