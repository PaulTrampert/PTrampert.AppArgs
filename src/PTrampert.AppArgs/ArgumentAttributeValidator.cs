using System.Collections.Generic;
using System.Reflection;
using PTrampert.AppArgs.Attributes;
using PTrampert.AppArgs.Exceptions;

namespace PTrampert.AppArgs
{
    internal class ArgumentAttributeValidator
    {
        public static void ValidateAttributes(IEnumerable<PropertyInfo> props)
        {
            var required = true;
            foreach (var prop in props)
            {
                var attrib = prop.GetCustomAttribute<ArgumentAttribute>();
                if (!required && attrib.IsRequired)
                {
                    throw new RequiredArgumentAfterOptionalException(attrib.Name ?? prop.Name);
                }
                required = attrib.IsRequired;
            }
        }
    }
}