using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Forecaster.Models.OpenWeather
{
    public enum ModeEnum
    {
        [Display(Name = "Current weather")]
        Current
    }
}