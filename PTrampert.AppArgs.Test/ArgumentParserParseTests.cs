using Xunit;
using System;
using PTrampert.AppArgs.Attributes;

namespace PTrampert.AppArgs.Test
{
    public class ArgumentParserParseTests
    {
        protected ArgumentParser<SampleArgsClass> Subject { get; set; }

        public ArgumentParserParseTests()
        {
            Subject = new ArgumentParser<SampleArgsClass>();
        }

        [Fact]
        public void CanProperlyParseWhenAllArgumentsAreProvided()
        {
            var args = new [] { "42", "test string", "5.5", "4/25/1988", "Test2"};
            var result = Subject.Parse(args, new SampleArgsClass());
            Assert.Equal(result.StringArg, "test string");
            Assert.Equal(result.IntArg, 42);
            Assert.Equal(result.DecimalArg, 5.5m);
            Assert.Equal(result.DateTimeArg, new DateTime(1988, 4, 25));
            Assert.Equal(result.EnumArg, SampleEnum.Test2);
        }

        [Fact]
        public void ParsesProperlyWhenOptionalArgumentsAreOmitted()
        {
            var args = new [] { "42", "test string", "5.5" };
            var result = Subject.Parse(args, new SampleArgsClass());
            Assert.Equal(result.StringArg, "test string");
            Assert.Equal(result.IntArg, 42);
            Assert.Equal(result.DecimalArg, 5.5m);
        }

    }

    public class SampleArgsClass
    {
        [Argument(1)]
        public string StringArg { get; set; }

        [Argument(0)]
        public int IntArg { get; set; }

        [Argument(2)]
        public decimal DecimalArg { get; set; }

        [Argument(3, IsRequired = false)]
        public DateTime DateTimeArg { get; set; }

        [Argument(4, IsRequired = false)]
        public SampleEnum EnumArg { get; set; }
    }

    public enum SampleEnum
    {
        Test1,
        Test2,
        Test3
    }
}