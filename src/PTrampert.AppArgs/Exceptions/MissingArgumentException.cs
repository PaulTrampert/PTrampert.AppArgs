using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTrampert.AppArgs.Exceptions
{
    public class MissingArgumentException : Exception
    {
        public MissingArgumentException(string name) : base($"Argument {name} is missing") { }
    }
}
