using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public static class EnumExtensions
{ 
    public static string GetDisplayName(this Enum enumValue, bool shortName = false)
    {
        var attribute = enumValue.GetType()?
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>();
        
        if (shortName)
            return attribute?.ShortName;
        else
            return attribute?.Name;
            
    } 
}