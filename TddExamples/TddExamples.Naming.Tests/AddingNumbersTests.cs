namespace TddExamples.Naming.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    // Context specification style, multiple asserts per action.
    public class AddingNumbersTests
    {
        public class WhenGivenInvalidInput : ContextSpecification
        {
            private Exception exception;
            private Widget sut;

            protected override void Context()
            {
                base.Context();

                sut = new Widget(new ParserMap());
            }

            protected override void BecauseOf()
            {
                exception = Capture.Exception(() => sut.Add("blah"));
            }

            // Testing for exceptions.
            [Test]
            public void ItShouldThrowAnException()
            {
                exception.Should().BeOfType<ArgumentException>();
            }

            // Tag integration tests, useful to ignore
            [Test, Integration]
            public void IntegrationTestsShouldBeIgnored()
            {
                Assert.Fail("because the database isn't setup");
            }
        }    
    }
}