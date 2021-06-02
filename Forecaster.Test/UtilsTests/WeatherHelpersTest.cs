using System;
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
            var coordinates = new Coordinates { Latitude = coords };
            var cityWeather = new CityWeather() { Coordinates = coordinates };

            var coordinate = cityWeather.GetCoordsDirections(GeoCoordinate.Latitude);

            Assert.Equal(valid, coordinate);
        }

        [Theory]
        [InlineData(0.0, "0°")]
        [InlineData(1.0, "1° E")]
        [InlineData(-1.0, "1° W")]
        public void GetCoordsDirections_LongitudeString_ValidDirection(float coords, string valid)
        {
            var coordinates = new Coordinates { Longitude = coords };
            var cityWeather = new CityWeather() { Coordinates = coordinates };

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

        [Theory]
        [InlineData(IconSize.Four, "http://openweathermap.org/img/wn/01d@4x.png")]
        [InlineData(IconSize.Two, "http://openweathermap.org/img/wn/01d@2x.png")]
        [InlineData(IconSize.One, "http://openweathermap.org/img/wn/01d.png")]
        public void GetIconSourceUri_DifferentSizes_ValidUri(IconSize size, string uri)
        {
            var weather = new Weather() { Icon = "01d" };
            var cityWeather = new CityWeather() { Weather = new List<Weather> { weather } };

            var iconUri = cityWeather.GetIconSourceUri(size);
            Assert.Equal(iconUri, uri);
        }

        [Fact]
        public void GetFormattedTemperature_DoubleValue_RoundedValue()
        {
            var main = new Main() { Temp = 0.55f };
            var cityWeather = new CityWeather() { Main = main };

            Assert.Equal(cityWeather.GetFormattedTemperature(), "0.6");
        }

        [Theory]
        [InlineData(1f, "1")]
        [InlineData(0.55f, "0.6")]
        [InlineData(-0.55f, "-0.6")]
        public void GetFormattedTemperature_NonRoundedFloat_RoundedValue(float temperature, string valid)
        {
            var main = new Main() { Temp = temperature };
            var cityWeather = new CityWeather() { Main = main };

            Assert.Equal(cityWeather.GetFormattedTemperature(), valid);
        }

        [Theory]
        [InlineData(1f, "1")]
        [InlineData(0.55f, "0.6")]
        [InlineData(-0.55f, "-0.6")]
        public void GetFormattedMinTemperature_NonRoundedFloat_RoundedValue(float temperature, string valid)
        {
            var main = new Main() { TempMin = temperature };
            var cityWeather = new CityWeather() { Main = main };

            Assert.Equal(cityWeather.GetFormattedMinTemperature(), valid);
        }

        [Theory]
        [InlineData(1f, "1")]
        [InlineData(0.55f, "0.6")]
        [InlineData(-0.55f, "-0.6")]
        public void GetFormattedMaxTemperature_NonRoundedFloat_RoundedValue(float temperature, string valid)
        {
            var main = new Main() { TempMax = temperature };
            var cityWeather = new CityWeather() { Main = main };

            Assert.Equal(cityWeather.GetFormattedMaxTemperature(), valid);
        }

        [Theory]
        [InlineData(1f, "1")]
        [InlineData(0.55f, "0.6")]
        [InlineData(-0.55f, "-0.6")]
        public void GetFormattedFeelsLikeTemperature_NonRoundedFloat_RoundedValue(float temperature, string valid)
        {
            var main = new Main() { FeelsLike = temperature };
            var cityWeather = new CityWeather() { Main = main };

            Assert.Equal(cityWeather.GetFormattedFeelsLikeTemperature(), valid);
        }

        [Theory]
        [InlineData(1f, "1")]
        [InlineData(0.51f, "1")]
        [InlineData(0.49f, "0")]
        public void GetRoundedWind_NonRoundedFloat_RoundedValue(float temperature, string valid)
        {
            var wind = new Wind() { Speed = temperature };
            var cityWeather = new CityWeather() { Wind = wind };

            Assert.Equal(cityWeather.GetRoundedWind(), valid);
        }

        [Theory]
        [InlineData(22.5f, "🡥")]
        [InlineData(67.5f, "🡢")]
        [InlineData(112.5f, "🡦")]
        [InlineData(157.5f, "🡣")]
        [InlineData(202.5f, "🡧")]
        [InlineData(247.5f, "🡠")]
        [InlineData(292.5f, "🡤")]
        [InlineData(337.5f, "🡡")]
        public void GetWindDirection_DegreesFloat_ValidDirectionArrow(float degrees, string valid)
        {
            var wind = new Wind() { Degrees = degrees };
            var cityWeather = new CityWeather() { Wind = wind };

            Assert.Equal(valid, cityWeather.GetWindDirection());
        }

        [Fact]
        public void GetWindDirection_NullInput_ThrowNullReferenceException()
        {
            var cityWeather = new CityWeather();

            Assert.Throws<NullReferenceException>(() => cityWeather.GetWindDirection());
        }

        [Fact]
        public void GetVisibility_ValueBelowOneThousand_ReturnInMeters()
        {
            var cityWeather = new CityWeather() { Visibility = 0 };

            var visibility = cityWeather.GetVisibility();

            Assert.Equal("0 m", visibility);
        }

        [Theory]
        [InlineData("1 km", 1000)]
        [InlineData("1.5 km", 1500)]
        [InlineData("1.6 km", 1550)]
        public void GetVisibility_ValueOverOneThousand_ReturnInKilometers(string expected, int value)
        {
            var cityWeather = new CityWeather() { Visibility = value };

            var visibility = cityWeather.GetVisibility();

            Assert.Equal(expected, visibility);
        }

        [Theory]
        [InlineData("00:00", 0)]
        [InlineData("01:46", 1000000000)]
        public void GetSunriseTime_UnixTime_ValidDateTimeString(string expected, long unixTime)
        {
            var sysData = new SysData() { Sunrise = unixTime };
            var cityWeather = new CityWeather() { SysData = sysData };

            var sunriseTime = cityWeather.GetSunriseTime();

            Assert.Equal(expected, sunriseTime);
        }


        [Theory]
        [InlineData("00:00", 0)]
        [InlineData("01:46", 1000000000)]
        public void GetSunsetTime_UnixTime_ValidDateTimeString(string expected, long unixTime)
        {
            var sysData = new SysData() { Sunset = unixTime };
            var cityWeather = new CityWeather() { SysData = sysData };

            var sunsetTime = cityWeather.GetSunsetTime();

            Assert.Equal(expected, sunsetTime);
        }
















    }
}