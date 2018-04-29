using System;

namespace PTrampert.AppArgs.Exceptions
{
    /// <summary>
    /// Thrown when an optional argument occurrs before a required argument.
    /// </summary>
    public class RequiredArgumentAfterOptionalException : Exception
    {
        internal RequiredArgumentAfterOptionalException(string name) : base($"The required argument {name} comes after an optional argument.") { }
    }
}
