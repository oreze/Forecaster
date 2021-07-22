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
        public static string GetCoordsDirections(this CityWeather weather, GeoCoordinate coord)
        {
            Coordinates coords = weather.Coordinates;
            if (coord is GeoCoordinate.Longitude)
            {
                string longitudeDirection;

                if (coords?.Longitude > 0)
                    longitudeDirection = coords.Longitude + "° E";
                else if (coords?.Longitude < 0)
                    longitudeDirection = Math.Abs((double)coords.Longitude) + "° W";
                else if (coords?.Longitude == 0)
                    longitudeDirection = coords.Longitude + "°";
                else
                    longitudeDirection = "n/a";

                return longitudeDirection;
            }
            else
            {
                string latitudeDirection;

                if (coords?.Latitude > 0)
                    latitudeDirection = coords.Latitude + "° N";
                else if (coords?.Latitude < 0)
                    latitudeDirection = Math.Abs((double)coords.Latitude) + "° S";
                else if (coords?.Latitude == 0)
                    latitudeDirection = coords.Latitude + "°";
                else
                    latitudeDirection = "n/a";

                return latitudeDirection;
            }
        }

        public static string GetCountry(this CityWeather weather)
        {
            foreach (Countries value in Enum.GetValues(typeof(Countries)))
            {
                var foundedShortName = value.GetDisplayName(true);
                if (foundedShortName.Equals(weather.SysData?.Country?.ToUpper()))
                    return value.GetDisplayName();
            }
            return null;
        }

        public static string GetIconSourceUri(this CityWeather weather, IconSize size)
        {
            string Uri = "http://openweathermap.org/img/wn/" + weather.Weather?.First()?.Icon;
            Uri += size switch
            {
                IconSize.One => "",
                IconSize.Two => "@2x",
                IconSize.Four => "@4x",
                _ => ""
            };
            Uri += ".png";
            return Uri;
        }

        public static string GetFormattedFloat(this CityWeather weather, float param)
        {
            return Math.Round(param, 1)
                .ToString()
                .Replace(",", ".");
        }

        public static string GetWindDirection(this CityWeather weather) =>
            weather.Wind?.Degrees switch
            {
                float x when x >= 337.5 || x < 22.5 => Arrows.North.GetDisplayName(true),
                float x when x >= 22.5 && x < 67.5 => Arrows.NorthEast.GetDisplayName(true),
                float x when x >= 67.5 && x < 112.5 => Arrows.East.GetDisplayName(true),
                float x when x >= 112.5 && x < 157.5 => Arrows.SouthEast.GetDisplayName(true),
                float x when x >= 157.5 && x < 202.5 => Arrows.South.GetDisplayName(true),
                float x when x >= 202.5 && x < 247.5 => Arrows.SouthWest.GetDisplayName(true),
                float x when x >= 247.5 && x < 292.5 => Arrows.West.GetDisplayName(true),
                float x when x >= 292.5 && x < 337.5 => Arrows.NorthWest.GetDisplayName(true),
                _ => "n/a"
            };

        public static string GetVisibility(this CityWeather weather) =>
            weather.Visibility switch
            {
                int x when x < 1000 => x + " m",
                int x when x >= 1000 => Math.Round(x / 1000.0, 1).ToString().Replace(",", ".") + " km",
                _ => "n/a"
            };

        public static string GetSunriseTime(this CityWeather weather)
        {
            DateTime UnixTime = new();
            if (weather.SysData != null)
                return UnixTime.AddSeconds(weather.SysData.Sunrise).ToString("t");
            return "n/a";
        }
        public static string GetSunsetTime(this CityWeather weather)
        {
            DateTime UnixTime = new();
            if (weather.SysData != null)
                return UnixTime.AddSeconds(weather.SysData.Sunset).ToString("t");
            return "n/a";
        }
    }
}