using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace HippoBilling.Core.Enum
{
    public static class EnumExtension
    {
        public static List<KeyValuePair<int, string>> GetValues(Type enumType,CultureInfo culture) 
        {

            TypeConverter converter = TypeDescriptor.GetConverter(enumType);
           
            return (from System.Enum value in System.Enum.GetValues(enumType) select new KeyValuePair<int, string>(Convert.ToInt32(value), converter.ConvertToString(null, culture, value))).ToList();
        }

        public static List<KeyValuePair<int, string>> GetValues(Type enumType)
        {
            return GetValues(enumType, CultureInfo.CurrentUICulture);
        }

        public static string GetText(this System.Enum @enum, CultureInfo culture)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(@enum.GetType());
            return converter.ConvertToString(null, culture,@enum);
        }

        public static string GetText(this System.Enum @enum)
        {
            return @enum.GetText(CultureInfo.CurrentUICulture);
        }
    }
}
