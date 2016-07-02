using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PTrampert.AppArgs.Exceptions
{
    public class RequiredArgumentAfterOptionalException : Exception
    {
        public RequiredArgumentAfterOptionalException(string name) : base($"The required argument {name} comes after an optional argument.") { }
    }
}
