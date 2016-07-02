using System;

namespace PTrampert.AppArgs.Exceptions
{
    public class UnparseableArgumentException : Exception
    {
        public UnparseableArgumentException(string name) : base($"The argument {name} cannot be parsed.")
        {
        }
    }
}