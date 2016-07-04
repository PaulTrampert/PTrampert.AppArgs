using System;

namespace PTrampert.AppArgs.Exceptions
{
    /// <summary>
    /// Exception thrown when an argument can't be parsed.
    /// </summary>
    public class ParsingException : Exception 
    {
        internal ParsingException(string name, Exception e = null) : base($"Error parsing {name}", e)
        {

        }
    }
}