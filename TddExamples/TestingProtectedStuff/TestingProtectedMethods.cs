using System.Collections.Generic;
using FluentAssertions;
using TestingProtectedStuff.ImportedLibrary;
using Xunit;

namespace TestingProtectedStuff
{
    public class TestingProtectedMethods
    {
        [Fact]
        public void MyTest()
        {
            var sut = new TestableChildClass();

            var result = sut.DoSomething("Hello, world!");

            result.Should().Contain("Hello, world!");
        }

        private class TestableChildClass : ChildClass
        {
            public new IEnumerable<string> DoSomething(string input)
            {
                return base.DoSomething(input);
            }
        }
    }

    public class ChildClass : BaseClass
    {
        protected override IEnumerable<string> DoSomething(string input)
        {
            yield return input;
        }
    }
}
