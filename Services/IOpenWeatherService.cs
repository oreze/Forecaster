using System.Collections.Generic;
using System.Threading.Tasks;
using Forecaster.Models.Weather;

namespace Forecaster.Services
{
    public interface IOpenWeatherService
    {
        public Task<IEnumerable<CityWeather>> GetLocationWeather();
    }
}