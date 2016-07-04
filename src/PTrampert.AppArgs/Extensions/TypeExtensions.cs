using System;
using System.Reflection;

namespace PTrampert.AppArgs.Extensions
{
    internal static class TypeExtensions
    {
        /// <summary>
        /// Returns a parsing function for the given <c>Type</c>
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A method to parse the type from a string.</returns>
        internal static Func<string, object> GetParseMethod(this Type type)
        {
            if (type == typeof(string)) 
            {
                return (arg) => arg;
            }
            if (type.GetTypeInfo().IsEnum) 
            {
                return (arg) => Enum.Parse(type, arg);
            }
            var parseMethod = type.GetRuntimeMethod("Parse", new []{typeof(string)});
            if (parseMethod != null && parseMethod.IsStatic) 
            {
                return (arg) => parseMethod.Invoke(null, new[]{arg});
            }
            return null;
        }
    }
}