using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PTrampert.AppArgs.Attributes;
using PTrampert.AppArgs.Exceptions;
using PTrampert.AppArgs.Extensions;

namespace PTrampert.AppArgs
{
    /// <summary>
    /// Parser for parsing command line options.
    /// </summary>
    public class OptionParser<T> where T : new()
    {
        private IEnumerable<PropertyInfo> _optionProperties;

        private bool _strict;

        /// <summary>
        /// Initializes an option parser.
        /// </summary>
        public OptionParser(bool strict = true)
        {
            _strict = strict;
            var type = typeof(T);
            _optionProperties = type.GetRuntimeProperties().Where(pi => pi.GetCustomAttribute<OptionAttribute>() != null);
            OptionAttributeValidator.ValidateOptionAttributes(_optionProperties);
        }

        /// <summary>
        /// Parse command line options into the given object.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <param name="obj">The object to store the options in.</param>
        /// <returns>The populated object.</returns>
        public T Parse(string[] args, T obj)
        {
            for (int i = 0; i < args.Length; i++) 
            {
                var option = args[i];
                PropertyInfo prop;
                OptionAttribute attrib;
                if (option.StartsWith("-"))
                {
                    option = option.Substring(1);
                    try
                    {
                        prop = _optionProperties.Where(p =>
                        {
                            var attr = p.GetCustomAttribute<OptionAttribute>();
                            return (attr.Name ?? p.Name) == option || attr.ShortName == option;
                        }).Single();
                        attrib = prop.GetCustomAttribute<OptionAttribute>();
                    }
                    catch (Exception e)
                    {
                        if (_strict)
                            throw new UnrecognizedOptionException(option, e);
                        else
                            continue;
                    }
                }
                else
                {
                    continue;
                }

                if (prop.PropertyType == typeof(bool))
                {
                    prop.SetValue(obj, true);
                }
                else
                {
                    i++;
                    if (i == args.Length) continue;
                    var stringVal = args[i];
                    var parseMethod = prop.PropertyType.GetParseMethod();
                    try
                    {
                        prop.SetValue(obj, parseMethod(stringVal));
                    }
                    catch (Exception e)
                    {
                        throw new ParsingException(option, e);
                    }
                }
            }
            return obj;
        }
    }
}
