using System;

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
