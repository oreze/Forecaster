using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

// Source code: https://stackoverflow.com/questions/13099834/how-to-get-the-display-name-attribute-of-an-enum-member-via-mvc-razor-code
/// <summary>
/// Static class to help operating on enums. Allows user to get values from DisplayAttribute.
/// </summary>
/// <typeparam name="T">Enum to operate on</typeparam>
public static class EnumExtensions
{ 
    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()?
            .GetMember(enumValue.ToString())?
            .First()?
            .GetCustomAttribute<DisplayAttribute>()?
            .Name;
    } 
    public static string GetShortName(this Enum enumValue)
    {
        return enumValue.GetType()?
            .GetMember(enumValue.ToString())?
            .First()?
            .GetCustomAttribute<DisplayAttribute>()?
            .ShortName;
    }
}