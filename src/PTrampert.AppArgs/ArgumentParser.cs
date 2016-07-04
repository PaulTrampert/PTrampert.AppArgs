using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PTrampert.AppArgs.Attributes;
using PTrampert.AppArgs.Exceptions;

namespace PTrampert.AppArgs
{
    /// <summary>
    /// Parser for parsing ordered arguments.
    /// </summary>
    public class ArgumentParser<T> where T : new()
    {
        private IEnumerable<PropertyInfo> _argumentProperties;

        /// <summary>
        /// Initializes an argument parser.
        /// </summary>
        public ArgumentParser()
        {
            var type = typeof(T);
            _argumentProperties = type.GetRuntimeProperties().Where(pi => pi.GetCustomAttribute<ArgumentAttribute>() != null)
                .OrderBy(pi => pi.GetCustomAttribute<ArgumentAttribute>().Order);
            ArgumentAttributeValidator.ValidateAttributes(_argumentProperties);
        }

        /// <summary>
        /// Parse ordered arguments into the given object.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <param name="obj">The object to store the arguments in.</param>
        /// <returns>The populated object.</returns>
        public T Parse(string[] args, T obj)
        {
            foreach (var prop in _argumentProperties)
            {
                var attrib = prop.GetCustomAttribute<ArgumentAttribute>();
                if (args.Length <= attrib.Order)
                {
                    if (attrib.IsRequired)
                    {
                        throw new MissingArgumentException(attrib.Name ?? prop.Name);
                    }
                    break;
                }
                var parseMethod = attrib.GetParseMethod(prop);
                try 
                {
                    prop.SetValue(obj, parseMethod(args[attrib.Order]));
                } catch (Exception e) 
                {
                    throw new ParsingException(attrib.Name ?? prop.Name, e);
                }
            }
            return obj;
        }
    }
}
