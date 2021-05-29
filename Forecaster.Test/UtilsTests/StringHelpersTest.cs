using System;
using Forecaster.Utils;
using Xunit;

namespace Forecaster.Test
{
    public class StringHelperTest
    {
        [Fact]
        public void Capitalize_NullInput_ThrowsArgumentNullException()
        {
            string STRING = null;
            
            Assert.Throws<ArgumentNullException>(() => STRING.Capitalize());
        }

        [Fact]
        public void Capitalize_EmptyString_ThrowsArgumentException()
        {
            string STRING = "";
            
            Assert.Throws<ArgumentException>(() => STRING.Capitalize());
        }

        [Theory]
        [InlineData("a", "A")]
        [InlineData("aaa", "Aaa")]
        [InlineData("Aaa", "Aaa")]
        [InlineData("AAA", "AAA")]
        public void Capitalize_StringInput_ReturnCapitalizedString(string item, string valid)
        {
            var capitalized = item.Capitalize();
            
            Assert.Equal(valid, capitalized);
        }
    }
}