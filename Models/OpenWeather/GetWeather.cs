namespace Forecaster.Models.OpenWeather
{
    public class GetWeather
    {
        public string Location { get; set; } = "current";
        public ModeEnum Mode { get; set; }
    }
}