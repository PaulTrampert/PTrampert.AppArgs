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
                ValidateRequired(attrib, prop, required);
                required = attrib.IsRequired;
                ValidateParseable(attrib, prop);
            }
        }

        private static void ValidateRequired(ArgumentAttribute attrib, PropertyInfo prop, bool required) 
        {
            if (!required && attrib.IsRequired)
            {
                throw new RequiredArgumentAfterOptionalException(attrib.Name ?? prop.Name);
            }
        }

        private static void ValidateParseable(ArgumentAttribute attrib, PropertyInfo prop)
        {
            var propType = prop.PropertyType;
            if (attrib.GetParseMethod(prop) == null) 
            {
                throw new UnparseableArgumentException(attrib.Name ?? prop.Name);
            }
        }
    }
}