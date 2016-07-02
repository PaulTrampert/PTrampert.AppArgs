using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PTrampert.AppArgs.Attributes;
using PTrampert.AppArgs.Exceptions;

namespace PTrampert.AppArgs
{
    public class ArgumentParser<T> where T : new()
    {
        private IEnumerable<PropertyInfo> _argumentProperties;
        public ArgumentParser()
        {
            var type = typeof(T);
            _argumentProperties = type.GetRuntimeProperties().Where(pi => pi.GetCustomAttribute<ArgumentAttribute>() != null)
                .OrderBy(pi => pi.GetCustomAttribute<ArgumentAttribute>().Order);
            ArgumentAttributeValidator.ValidateAttributes(_argumentProperties);
        }

        public T Parse(string[] args, T obj)
        {
            foreach (var prop in _argumentProperties)
            {
                var attrib = prop.GetCustomAttribute<ArgumentAttribute>();
                if (args.Length >= attrib.Order)
                {
                    if (attrib.IsRequired)
                    {
                        throw new MissingArgumentException(attrib.Name ?? prop.Name);
                    }
                    break;
                }
                var propertyType = prop.PropertyType;
                if (propertyType == typeof(string))
                {
                    prop.SetValue(obj, args[attrib.Order]);
                    continue;
                }
                var parseMethod = propertyType.GetRuntimeMethod("Parse", new[] {typeof(string)}) ??
                                  propertyType.GetRuntimeMethod("Parse", new[] {typeof(Type), typeof(string)});
                if (parseMethod == null || !parseMethod.IsStatic)
                {
                    throw new UnparseableArgumentException(attrib.Name ?? prop.Name);
                }
                if (parseMethod.GetParameters().Length == 1)
                {
                    var value = parseMethod.Invoke(null, new[] {args[attrib.Order]});
                    prop.SetValue(obj, value);
                }
                else
                {
                    var value = parseMethod.Invoke(null, new object[] {prop.PropertyType, args[attrib.Order]});
                    prop.SetValue(obj, value);
                }
            }
            return obj;
        }
    }
}
