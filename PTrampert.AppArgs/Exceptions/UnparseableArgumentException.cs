using System;

namespace PTrampert.AppArgs.Exceptions
{
    /// <summary>
    /// Thrown when the argument is unparseable.
    /// </summary>
    public class UnparseableArgumentException : Exception
    {
        internal UnparseableArgumentException(string name) : base($"The argument {name} cannot be parsed.")
        {
        }
    }
}