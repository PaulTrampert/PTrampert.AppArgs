using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using PTrampert.AppArgs;
using PTrampert.AppArgs.Attributes;
using PTrampert.AppArgs.Exceptions;

namespace PTrampert.AppArgs.Test
{
    public class ArgumentParserConstructorTests
    {
        [Fact]
        public void ShouldThrowWhenOptionalArgumentPrecedesRequired()
        {
            var exception = Assert.Throws<RequiredArgumentAfterOptionalException>(() => new ArgumentParser<BadArgumentsClass>());
            Assert.Equal("The required argument Test1 comes after an optional argument.", exception.Message);
        }

        [Fact]
        public void ShouldNotThrowWhenOptionalArgumentAfterRequired() 
        {
            var parser = new ArgumentParser<GoodArgumentsClass>();
            Assert.False(parser == null);
        }
    }

    public class BadArgumentsClass
    {
        [Argument(1)]
        public string Test1 { get; set; }
        
        [Argument(0, IsRequired = false )]
        public string Test2 { get; set; }
    }

    public class GoodArgumentsClass
    {
        [Argument(0)]
        public string Test1 { get; set; }

        [Argument(1, IsRequired = false)]
        public string Test2 { get; set; }
    }
}
