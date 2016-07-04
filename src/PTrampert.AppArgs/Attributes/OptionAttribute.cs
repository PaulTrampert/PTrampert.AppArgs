using System;

namespace PTrampert.AppArgs.Attributes
{
    /// <summary>
    /// Attribute specifying an option. Options can come in any order, but must always have either a Name, a ShortName, or both.
    /// When specified by the command line, an options Name must be preceded by '--', and its short name preceded by '-'. When
    /// an OptionAttribute is applied to a bool property, it will be treated as a flag.
    /// </summary>
    /// <example>
    /// An option specified with the following attribute:
    /// <code>
    /// [Option(Name = "test", ShortName = 't')]
    /// </code>
    /// Would be specified in the command line by either <code>--test</code> or <code>-t</code>.
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class OptionAttribute : Attribute
    {
        /// <summary>
        /// Name of the option. To use this option from the command line, you would call it with '--Name'
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short name of the option. To use this option from the command line, you would call it with '-ShortName'
        /// </summary>
        public char? ShortName { get; set; }

        /// <summary>
        /// Boolean indicating whether or not this option is required.
        /// </summary>
        public bool IsRequired { get; set; }
    }
}
