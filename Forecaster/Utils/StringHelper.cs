using System;
using System.Linq;

namespace Forecaster.Utils
{
    public static class StringHelper
    {
        public static string Capitalize(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString().ToUpper() + (input.Length > 1 ? input.Substring(1) : String.Empty)
            };
    }
}