using Xunit;
using System;
using PTrampert.AppArgs.Attributes;
using PTrampert.AppArgs.Exceptions;

namespace PTrampert.AppArgs.Test
{
    public class OptionParserParseTests
    {
        protected OptionParser<SampleOpts> Subject { get; set; }

        public OptionParserParseTests()
        {
            Subject = new OptionParser<SampleOpts>();
        }

        [Fact]
        public void AllOptsAreOptional()
        {
            var args = new string[0];
            var opts = Subject.Parse(args, new SampleOpts());
            Assert.Null(opts.StringArg);
            Assert.Equal(0, opts.IntArg);
            Assert.Equal(0m, opts.DecimalArg);
            Assert.Equal(false, opts.BoolArg);
            Assert.Equal(default(DateTime), opts.DateTimeArg);
            Assert.Equal(default(SampleEnum), opts.EnumArg);
        }

        [Fact]
        public void ThrowsForUnrecognizedOption() 
        {
            var args = new []{"-test"};
            Assert.Throws<UnrecognizedOptionException>(() => Subject.Parse(args, new SampleOpts()));
        }

        [Fact]
        public void CanParseOnPropertyName() 
        {
            var args = new []{"-StringArg", "some value"};
            var opts = Subject.Parse(args, new SampleOpts());
            Assert.Equal("some value", opts.StringArg);
        }

        [Fact]
        public void CanParseOnGivenName()
        {
            var args = new [] {"-string", "some value"};
            var opts = Subject.Parse(args, new SampleOpts());
            Assert.Equal("some value", opts.StringArg);
        }

        [Fact]
        public void CanParseOnShortName()
        {
            var args = new [] {"-i", "42"};
            var opts = Subject.Parse(args, new SampleOpts());
            Assert.Equal(42, opts.IntArg);
        }

        [Fact]
        public void CanParseFlagsAmongOtherOptions()
        {
            var args = new [] {"-i", "42", "-BoolArg", "-string", "some value"};
            var opts = Subject.Parse(args, new SampleOpts());
            Assert.Equal(42, opts.IntArg);
            Assert.Equal(true, opts.BoolArg);
            Assert.Equal("some value", opts.StringArg);
        }
    }

    public class SampleOpts
    {
        [Option(Name = "string")]
        public string StringArg { get; set; }

        [Option(ShortName = "i")]
        public int IntArg { get; set; }

        [Option]
        public bool BoolArg { get; set; }

        [Option(Name = "decimal", ShortName = "d")]
        public decimal DecimalArg { get; set; }

        [Option]
        public DateTime DateTimeArg { get; set; }

        [Option]
        public SampleEnum EnumArg { get; set; }
    }
}