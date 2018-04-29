using System;

namespace PTrampert.AppArgs.Exceptions
{
    /// <summary>
    /// Thrown when an unrecognized option is encountered.
    /// </summary>
    public class UnrecognizedOptionException : Exception
    {
        internal UnrecognizedOptionException(string name, Exception innerException = null) : base($"Option {name} was unrecognized", innerException)
        {

        }
    }
}