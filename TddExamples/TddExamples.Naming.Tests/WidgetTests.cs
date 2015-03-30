namespace TddExamples.Naming.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    // Arrange, Act, Assert
    public class WidgetTests
    {
        // Nested class is method being tested.
        public class Add : WidgetTests
        {
            // Test names are condition and expected together.
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

            // You can use underscores too
            [Test]
            public void WhenGivenMultipleNumbers_ItShouldReturnTheSum()
            {
                const string listOfNumbers = "1,2";
                const int sumOfTheNumbers = 3;
                var sut = GetWidget();

                var result = sut.Add(listOfNumbers);

                result.Should().Be(sumOfTheNumbers);                
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
        }

        public class Assertions : WidgetTests
        {
            // Using an attribute. This breaks the AAA pattern.
            [Test, ExpectedException(typeof(ArgumentException))]
            public void ItShouldThrowAnExceptionWhenGivenInvalidInput()
            {
                GetWidget().Add("blah");
            }

            // Capturing the exception for use in an assertion is better.
            [Test]
            public void ItShouldDoSomething()
            {
                Capture.Exception(() => GetWidget().Add("blah"))
                    .Should().BeOfType<ArgumentException>();
            }
        }

        // try to use a factory if you need it more than once
        private static Widget GetWidget()
        {
            // this helps hide the dependency from the test, +1 maintainability
            return new Widget(new ParserMap());
        }
    }
}