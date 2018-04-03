namespace TddExamples.Naming.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    // Context specification style, multiple asserts per action.
    public class AddingNumbersTests : ContextSpecification
    {
        private Widget sut;

        protected override void Context()
        {
            base.Context();

            sut = new Widget(new ParserMap());
        }

        // each scenario becomes a class
        public class WhenGivenAnEmptyString : AddingNumbersTests
        {
            private int result;
            private const string Empty = "";
            private const int DefaultValue = 0;

            protected override void BecauseOf()
            {
                result = sut.Add(Empty);
            }

            [Test]
            public void ItShouldReturnTheDefaultValue()
            {
                result.Should().Be(DefaultValue);
            }
        }

        public class WhenGivenANumber : AddingNumbersTests
        {
            private int result;
            private const string OneNumber = "1";
            private const int ExpectedValue = 1;

            protected override void BecauseOf()
            {
                result = sut.Add(OneNumber);
            }

            [Test]
            public void ItShouldReturnTheNumber()
            {
                result.Should().Be(ExpectedValue);
            }
        }

        public class WhenGivenMoreThanOneNumber : AddingNumbersTests
        {
            private int result;
            private const string MultipleNumbers = "1,2";
            private const int ExpectedValue = 3;

            protected override void BecauseOf()
            {
                result = sut.Add(MultipleNumbers);
            }

            [Test]
            public void ItShouldReturnTheNumber()
            {
                result.Should().Be(ExpectedValue);
            }
        }

        public class WhenGivenInvalidInput : AddingNumbersTests
        {
            private Exception exception;

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
            [Test, Integration, Ignore]
            public void IntegrationTestsShouldBeIgnored()
            {
                Assert.Fail("because the database isn't setup");
            }
        }    
    }
}