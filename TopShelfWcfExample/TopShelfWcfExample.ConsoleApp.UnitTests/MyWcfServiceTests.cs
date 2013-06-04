namespace TopShelfWcfExample.ConsoleApp.UnitTests
{
    using FluentAssertions;
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyBusinessLibrary;

    public static class MyWcfServiceTests
    {
        public class MyWcfServiceContext : ContextSpecification
        {
            protected MyWcfService Sut;
            protected NewGreetingWithNameCommand GreetingWithNameCommand;

            protected override void Context()
            {
                base.Context();

                GreetingWithNameCommand = A.Fake<NewGreetingWithNameCommand>();
                Sut = new MyWcfService(GreetingWithNameCommand);
            }
        }

        [TestClass]
        public class WhenMakingAGreetRequest : MyWcfServiceContext
        {
            private string response;
            private const string ExpectedMessage = @"Hello, world.";

            protected override void BecauseOf()
            {
                response = Sut.Greet();
            }

            [TestMethod]
            public void ItShouldRetunrAGreeting()
            {
                response.Should().Be(ExpectedMessage);
            }
        }

        [TestClass]
        public class WhenMakingAGreetRequestWithAName : MyWcfServiceContext
        {
            private string response;
            private const string SampleInput = @"Chris";
            private const string ExpectedMessage = @"Hello, Chris";

            protected override void Context()
            {
                base.Context();

                A.CallTo(() => GreetingWithNameCommand.Execute())
                 .Invokes(() => GreetingWithNameCommand.Name.Should().Be(SampleInput))
                 .Returns(ExpectedMessage);
            }

            protected override void BecauseOf()
            {
                response = Sut.GetGrettingWithName(SampleInput);
            }

            [TestMethod]
            public void ItShouldReturnTheExpectedGreeting()
            {
                response.Should().Be(ExpectedMessage);
            }
        }
    }
}