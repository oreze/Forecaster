using Forecaster.Controllers;
using Forecaster.Models.Enums;
using Forecaster.Models.OpenWeather;
using Forecaster.Models.OpenWeather.Partial;
using Forecaster.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using System.Drawing;
using System.Security.Cryptography;
using System;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;
using Microsoft.AspNetCore.Http;

namespace Forecaster.Test.ControllersTest
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexGet_GetView_ViewResult()
        {
            var controller = new HomeController(openWeather: null);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void IndexPost_GetLocationWeather_RedirectToWeatherView()
        {
            var controller = new HomeController(openWeather: null);
            GetWeather getWeather = new() {Location = "London", Mode = Modes.Current};

            var redirectToActionResult = await controller.Index(getWeather);

            var validRequestResult = Assert.IsType<RedirectToActionResult>(redirectToActionResult);
            Assert.Equal("Weather", validRequestResult.ActionName);
        }

        [Fact]
        public async void WeatherGet_GetLocationWeather_ReturnWeatherView()
        {
            var openWeatherMock = new Mock<IOpenWeatherHttpService>();
            (CityWeather, HttpStatusCode) requestExpectedResult = (null, HttpStatusCode.OK);
            openWeatherMock
                .Setup(openWeather => openWeather.GetLocationWeather(It.IsAny<string>(), "metric"))
                .ReturnsAsync(requestExpectedResult);
            var controller = new HomeController(openWeather: openWeatherMock.Object);

            var result = controller.Weather("London");

            openWeatherMock
                .Verify(openWeather => openWeather.GetLocationWeather(It.IsAny<string>(), "metric"), Times.Once());
            await Assert.IsType<Task<IActionResult>>(result);
        }

        private CityWeather GetExampleCityWeather()
        {
                string cityWeatherJson = "{\"coord\":{\"lon\":-0.1257,\"lat\":51.5085},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"base\":\"stations\",\"main\":{\"temp\":22.77,\"feels_like\":22.67,\"temp_min\":20.55,\"temp_max\":23.94,\"pressure\":1024,\"humidity\":60},\"visibility\":10000,\"wind\":{\"speed\":0.45,\"deg\":281,\"gust\":2.24},\"clouds\":{\"all\":40},\"dt\":1623078332,\"sys\":{\"type\":2,\"id\":2019646,\"country\":\"GB\",\"sunrise\":1623037511,\"sunset\":1623096831},\"timezone\":3600,\"id\":2643743,\"name\":\"London\",\"cod\":200}";
                CityWeather cityWeather = JsonSerializer.Deserialize<CityWeather>(cityWeatherJson);
                return cityWeather;
        }
    }
}