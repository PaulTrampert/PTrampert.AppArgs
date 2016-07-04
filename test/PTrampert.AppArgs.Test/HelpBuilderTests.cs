using System;
using PTrampert.AppArgs.Attributes;
using Xunit;

namespace PTrampert.AppArgs.Test
{
    public class HelpBuilderTests
    {
        [Fact]
        public void BuildsHelpWithoutErrors()
        {
            var builder = new HelpBuilder<SampleArgs>();
            var helpString = builder.BuildHelp("test");
            Console.Write(helpString);
        }
    }

    public class SampleArgs
    {
        [Argument(0, Description = "This is a test argument")]
        public string TestArg { get; set; }

        [Argument(1, Name = "TestArg2", Description = "This is another test argument")]
        public string AnotherTestArg { get; set; }

        [Option(Description = "This is a test option")]
        public string TestOpt { get; set; }

        [Option(Name = "Test2", ShortName = "t2", Description = "This is another test option")]
        public String TestOpt2 { get; set; }
    }
}