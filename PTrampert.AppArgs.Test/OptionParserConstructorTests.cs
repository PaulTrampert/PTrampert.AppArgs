using Xunit;
using PTrampert.AppArgs.Attributes;
using PTrampert.AppArgs.Exceptions;
using System.IO;

namespace PTrampert.AppArgs.Test
{
    public class OptionParserConstructorTests
    {
        [Fact]
        public void ShouldNotThrowWhenOptionalArgumentAfterRequired() 
        {
            var parser = new OptionParser<GoodOptionsClass>();
            Assert.False(parser == null);
        }

        [Fact]
        public void ShouldThrowWhenArgumentAttachedToUnparseableProperty() 
        {
            var exception = Assert.Throws<UnparseableOptionException>(() => new OptionParser<UnparseableOption>());
            Assert.Equal("The option, File, cannot be parsed.", exception.Message);
        }
    }

    public class GoodOptionsClass
    {
        [OptionAttribute(Name = "test1", ShortName = "t1")]
        public string Test1 { get; set; }

        [OptionAttribute]
        public string Test2 { get; set; }
    }

    public class UnparseableOption
    {
        [OptionAttribute(Name = "File")]
        public Stream File {get;set;}
    }
}
