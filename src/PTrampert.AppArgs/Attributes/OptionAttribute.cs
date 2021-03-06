﻿using System;

namespace PTrampert.AppArgs.Attributes
{
    /// <summary>
    /// Attribute specifying an option. Options can come in any order, but must always have either a Name, a ShortName, or both.
    /// When specified by the command line, an options Name must be preceded by '--', and its short name preceded by '-'. When
    /// an OptionAttribute is applied to a bool property, it will be treated as a flag.
    /// </summary>
    /// <example>
    /// An option specified with the following attribute:
    /// <c>
    /// [Option(Name = "test", ShortName = 't')]
    /// </c>
    /// Would be specified in the command line by either <c>--test</c> or <c>-t</c>.
    /// </example>
    [AttributeUsage(AttributeTargets.Property)]
    public class OptionAttribute : Attribute
    {
        /// <summary>
        /// Name of the option. To use this option from the command line, you would call it with <c>-Name</c>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short name of the option. To use this option from the command line, you would call it with <c>-ShortName</c>
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// A short description of the option for use in the <c>-h|-help</c> output.
        /// </summary>
        public string Description { get; set; }
    }
}
