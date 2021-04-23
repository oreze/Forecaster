using System.ComponentModel.DataAnnotations;

namespace Forecaster.Models.Enums
{
    public enum Modes
    {
        [Display(Name = "Current")]
        Current,
        [Display(Name = "Daily")]
        Daily
        
    }
}