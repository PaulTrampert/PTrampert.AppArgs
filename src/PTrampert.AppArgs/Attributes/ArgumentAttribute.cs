﻿using System;

namespace PTrampert.AppArgs.Attributes
{
    /// <summary>
    /// Marks a property as a command line argument. Command line arguments must come in the same order, designated by Order, and must always occurr before Options.
    /// Required arguments must always come before optional arguments.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ArgumentAttribute : Attribute
    {
        /// <summary>
        /// Integer specifying what order the argument occurrs in.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Boolean specifying whether the argument is optional or not. Defaults to true.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// A human readable display name for the argument. Used in generated -h|-help documentation and error messages.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A description of the argument's purpose. Used in the auto-generated help text. 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Marks a property as a command line argument.
        /// </summary>
        /// <param name="order">The position at which to find the argument in the args array.</param>
        public ArgumentAttribute(int order)
        {
            Order = order;
            IsRequired = true;
        }
    }
}
