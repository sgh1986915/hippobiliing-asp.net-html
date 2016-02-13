using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace HippoBilling.Core.Enum
{
    public abstract class ResourceConverter :EnumConverter
    {
        private readonly ResourceManager _resourceManager;
        private class LookupTable : Dictionary<string, object> { }
        private readonly Dictionary<CultureInfo, LookupTable> _lookupTables = new Dictionary<CultureInfo, LookupTable>();

        protected ResourceConverter(Type type, ResourceManager resourceManager)
            : base(type)
        {
            _resourceManager = resourceManager;
           
        }

        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                object result =  GetValue(culture, (string)value);
                if (result == null)
                {
                    result = base.ConvertFrom(context, culture, value);
                }
                return result;
            }
            else
            {
                return base.ConvertFrom(context, culture, value);
            }
        }

        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (value != null && destinationType == typeof(string))
            {
                object result = GetValueText(culture, value);
                return result;
            }
            else
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }

        private LookupTable GetLookupTable(CultureInfo culture)
        {
            LookupTable result = null;
            if (culture == null)
                culture = CultureInfo.CurrentCulture;

            if (!_lookupTables.TryGetValue(culture, out result))
            {
                result = new LookupTable();
                foreach (object value in GetStandardValues())
                {
                    string text = GetValueText(culture, value);
                    if (text != null)
                    {
                        result.Add(text, value);
                    }
                }
                _lookupTables.Add(culture, result);
            }
            return result;
        }

        private string GetValueText(CultureInfo culture, object value)
        {
            Type type = value.GetType();
            string resourceName = string.Format("{0}_{1}", type.Name, value.ToString());
            string result = _resourceManager.GetString(resourceName, culture);
            if (result == null)
                result = resourceName;
            return result;
        }

        private object GetValue(CultureInfo culture, string text)
        {
            LookupTable lookupTable = GetLookupTable(culture);
            object result = null;
            lookupTable.TryGetValue(text, out result);
            return result;
        }

    }
}
