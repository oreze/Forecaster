using System.Collections.Generic;
using System.Runtime.InteropServices;
using Forecaster.Models.Enums;
using Forecaster.Models.OpenWeather;
using Forecaster.Models.OpenWeather.Partial;
using Forecaster.Services;
using Xunit;

namespace Forecaster.Test
{
    public class WeatherHelpersTest
    {
        [Theory]
        [InlineData(0.0, "0°")]
        [InlineData(1.0, "1° N")]
        [InlineData(-1.0, "1° S")]
        public void GetCoordsDirections_LatitudeString_ValidDirection(float coords, string valid)
        {
            var coordinates = new Coordinates {Latitude = coords};
            var cityWeather = new CityWeather() {Coordinates = coordinates};

            var coordinate = cityWeather.GetCoordsDirections(GeoCoordinate.Latitude);

            Assert.Equal(valid, coordinate);
        }

        [Theory]
        [InlineData(0.0, "0°")]
        [InlineData(1.0, "1° E")]
        [InlineData(-1.0, "1° W")]
        public void GetCoordsDirections_LongitudeString_ValidDirection(float coords, string valid)
        {
            var coordinates = new Coordinates {Longitude = coords};
            var cityWeather = new CityWeather() {Coordinates = coordinates};

            var coordinate = cityWeather.GetCoordsDirections(GeoCoordinate.Longitude);

            Assert.Equal(valid, coordinate);
        }

        [Theory]
        [InlineData("PL", "Poland")]
        [InlineData("GB", "United Kingdom")]
        [InlineData("US", "United States")]
        public void GetCountry_LongName_ValidName(string name, string validName)
        {
            var sysData = new SysData { Country = name };
            var cityWeather = new CityWeather() { SysData = sysData };

            var returnName = cityWeather.GetCountry();
            
            Assert.Equal(returnName, validName);
        }


        private CityWeather TestCityWeather()
        {
            var coordinates = new Coordinates
            {
                Longitude = 0.0,
                Latitude = 0.0
            };

            var weather = new List<Weather>
            {
                new Weather
                {
                    ID = 0,
                    Main = "Clouds",
                    Description = "Few clouds",
                    Icon = "02d"
                }
            };

            var main = new Main
            {
                Temp = 10f,
                FeelsLike = 10f,
                TempMin = 10f,
                TempMax = 10f,
                Pressure = 1000,
                Humidity = 50
            };

            var wind = new Wind
            {
                Speed = 10,
                Degrees = 180,
            };

            var clouds = new Clouds
            {
                All = 20
            };

            var sysData = new SysData
            {
                Country = "GB",
                ID = 2,
                Sunrise = 1499999999,
                Sunset = 1500000001,
                Type = 2
            };

            var based = "stations";
            var visibility = 10000;
            var dateTime = 1500000000;
            var id = 2643743;
            var name = "London";


            var cityWeather = new CityWeather
            {
                Base = based,
                Clouds = clouds,
                Coordinates = coordinates,
                DateTime = dateTime,
                ID = id,
                Main = main,
                Name = name,
                SysData = sysData,
                Visibility = visibility,
                Weather = weather
            };

            return cityWeather;
        }
    }
}