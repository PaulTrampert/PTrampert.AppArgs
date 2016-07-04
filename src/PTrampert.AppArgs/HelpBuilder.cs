using System.Linq;
using System.Reflection;
using System.Text;
using PTrampert.AppArgs.Attributes;

namespace PTrampert.AppArgs
{
    /// <summary>
    /// Class for building help output.
    /// </summary>
    public class HelpBuilder<T>
    {
        /// <summary>
        /// Builds help output for the object type.
        /// </summary>
        /// <param name="exeName">Name of the executable</param>
        /// <returns>Help output.</returns>
        public string BuildHelp(string exeName)
        {
            var usageBuilder = new StringBuilder();
            var argumentsBuilder = new StringBuilder();
            var optionsBuilder = new StringBuilder();
            var cliType = typeof(T);
            usageBuilder.Append($"Usage: {exeName}");
            var properties = cliType.GetRuntimeProperties();
            if (properties.Any(p => p.GetCustomAttribute<ArgumentAttribute>() != null))
            {
                usageBuilder.Append(" <ARGUMENTS>");
                argumentsBuilder.AppendLine("--ARGUMENTS--");
                argumentsBuilder.AppendLine($"{"Order".PadRight(6)}{"Name".PadRight(20)}{"Required".PadRight(10)}Description");
                foreach(var prop in properties.Where(p => p.GetCustomAttribute<ArgumentAttribute>() != null).OrderBy(p => p.GetCustomAttribute<ArgumentAttribute>().Order))
                {
                    var attrib = prop.GetCustomAttribute<ArgumentAttribute>();
                    var order = attrib.Order.ToString().PadRight(6);
                    var argName = (attrib.Name ?? prop.Name).PadRight(20);
                    var required = (attrib.IsRequired ? "x" : "").PadRight(10);
                    argumentsBuilder.AppendLine($"{order}{argName}{required}{attrib.Description}");
                }
            }
            if (properties.Any(p => p.GetCustomAttribute<OptionAttribute>() != null))
            {
                usageBuilder.Append(" [OPTIONS]");
                optionsBuilder.AppendLine("--OPTIONS--");
                optionsBuilder.AppendLine($"{"Option".PadRight(30)}Description");
                foreach(var prop in properties.Where(p => p.GetCustomAttribute<OptionAttribute>() != null).OrderBy(p => p.GetCustomAttribute<OptionAttribute>().Name ?? p.Name))
                {
                    var attrib = prop.GetCustomAttribute<OptionAttribute>();
                    var fullName = $"-{attrib.Name ?? prop.Name}";
                    var shortName = attrib.ShortName == null ? "" : $"|-{attrib.ShortName}";
                    var optName = $"{fullName}{shortName}".PadRight(30);
                    optionsBuilder.AppendLine($"{optName}{attrib.Description}");
                }
            }

            usageBuilder.AppendLine();
            usageBuilder.AppendLine();
            usageBuilder.Append(argumentsBuilder);
            usageBuilder.Append(optionsBuilder);
            return usageBuilder.ToString();
        }
    }
}