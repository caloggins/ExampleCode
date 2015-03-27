namespace TddExamples.Naming.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    public class WidgetTests
    {
        // Arrange, Act, Assert
        public class Add 
        {
            [Test]
            public void ItShouldReturnTheDefaultValueForAnEmptyString()
            {
                // Arrange... 'sut' is system under test.
                var sut = GetWidget();

                // Act
                var result = sut.Add("");

                // Assert
                result.Should().Be(0);
            }

            // consider not using magic strings & numbers
            [Test]
            public void ItShouldReturnTheNumberWhenThereIsOnlyOne()
            {
                const string singleNumber = "1";
                const int theSameNumber = 1;
                var sut = GetWidget();

                var result = sut.Add(singleNumber);

                result.Should().Be(theSameNumber);
            }

            // data-driven tests, reduces duplication
            [TestCase("", 0)]
            [TestCase("1", 1)]
            [TestCase("1,2", 3)]
            public void ItShouldReturnTheSumOfTheNumbers(string numbers, int expectedResult)
            {
                var sut = GetWidget();

                var sum = sut.Add(numbers);

                sum.Should().Be(expectedResult);
            }

            // try to use a factory if you need it more than once
            private static Widget GetWidget()
            {
                // this helps hide the dependency from the test, +1 maintainability
                return new Widget(new ParserMap());
            }
        }

        // Context specification style, multiple asserts per action.
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