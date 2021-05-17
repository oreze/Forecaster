using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forecaster.Models.Enums
{
    public enum Arrows
    {
        [Display(ShortName="🡡")]
        North,
        [Display(ShortName="🡥")]
        NorthEast,
        [Display(ShortName="🡢")]
        East,
        [Display(ShortName="🡦")]
        SouthEast,
        [Display(ShortName="🡣")]
        South,
        [Display(ShortName="🡧")]
        SouthWest,
        [Display(ShortName="🡠")]
        West,
        [Display(ShortName="🡤")]
        NorthWest
    }
}