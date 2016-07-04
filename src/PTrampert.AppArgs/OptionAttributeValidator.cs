using System;
using System.Collections.Generic;
using System.Reflection;
using PTrampert.AppArgs.Attributes;
using PTrampert.AppArgs.Exceptions;
using PTrampert.AppArgs.Extensions;

namespace PTrampert.AppArgs
{
    internal class OptionAttributeValidator
    {
        internal static void ValidateOptionAttributes(IEnumerable<PropertyInfo> props)
        {
            foreach (var prop in props) 
            {
                var attrib = prop.GetCustomAttribute<OptionAttribute>();
                if (prop.PropertyType.GetParseMethod() == null) 
                {
                    throw new UnparseableOptionException(attrib.Name ?? attrib.ShortName ?? prop.Name);
                }
            }
        }
    }
}