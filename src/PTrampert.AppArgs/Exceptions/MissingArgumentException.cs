using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTrampert.AppArgs.Exceptions
{
    /// <summary>
    /// Thrown when an argument is not found in the args array.
    /// </summary>
    public class MissingArgumentException : Exception
    {
        internal MissingArgumentException(string name) : base($"Argument {name} is missing") { }
    }
}
