using System;

namespace PTrampert.AppArgs.Exceptions
{
    /// <summary>
    /// Thrown when the option is unparseable.
    /// </summary>
    public class UnparseableOptionException : Exception
    {
        internal UnparseableOptionException(string name) : base($"The option, {name}, cannot be parsed.")
        {
        }
    }
}