namespace TopShelfWcfExample.MyBusinessLibrary.UnitTests
{
    using System;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class GreetingWithNameCommandTests
    {
        public class GreetingWithNameCommandContext : ContextSpecification
        {
            protected GreetingWithNameCommand Sut;

            protected override void Context()
            {
                base.Context();

                Sut = new GreetingWithNameCommand();
            }
        }

        [TestClass]
        public class WhenTheNameIsInvalid : GreetingWithNameCommandContext
        {
            private Exception thrownException;

            protected override void BecauseOf()
            {
                thrownException = Capture.Exception(() => Sut.Execute());
            }

            [TestMethod]
            public void AnExceptionShouldBeThrown()
            {
                thrownException.Should().BeOfType<MyCustomException>();
                thrownException.Message.Should().Be("A valid name was not provided.");
            }
        }

        [TestClass]
        public class WhenGivenAValidName : GreetingWithNameCommandContext
        {
            private string returnedGreeting;
            private const string SampleName = @"Chris";
            private const string ExpectedGreeting = @"Hello, Chris.";

            protected override void BecauseOf()
            {
                Sut.Name = SampleName;
                returnedGreeting = Sut.Execute();
            }

            [TestMethod]
            public void ItShouldReturnTheExpectedGreeting()
            {
                returnedGreeting.Should().Be(ExpectedGreeting);
            }
        }
    }
}