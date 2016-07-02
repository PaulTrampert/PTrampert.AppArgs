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
        public string Name { get; set; }

        public char? ShortName { get; set; }

        public bool Required { get; set; }
    }
}
