using System.ComponentModel.DataAnnotations;
using Forecaster.Models.Enums;

namespace Forecaster.Models.OpenWeather
{
    public class GetWeather
    {
        [Required(ErrorMessage = "You have to enter location.")]
        public string Location { get; set; } = "current";
        public Modes Mode { get; set; }
    }
}