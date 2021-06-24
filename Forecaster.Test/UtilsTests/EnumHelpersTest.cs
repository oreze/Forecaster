using System;
using Forecaster.Models.Enums;
using Xunit;

namespace Forecaster.Test
{
    public class EnumHelpersTest
    {
        [Theory]
        [InlineData(Countries.AND, "Andorra")]
        [InlineData(Countries.POL, "Poland")]
        [InlineData(Countries.USA, "United States")]
        public void GetDisplayName_ReturnValidName_ReturnTrue(Countries country, string name)
        {
            Assert.Equal(name, country.GetDisplayName());
        }
        
        [Theory]
        [InlineData(Countries.AND, "AD")]
        [InlineData(Countries.POL, "PL")]
        [InlineData(Countries.USA, "US")]
        public void GetShortName_ReturnValidName_ReturnTrue(Countries country, string shortName)
        {
            Assert.Equal(shortName, country.GetShortName());
        }
    }
}