namespace TopShelfWcfExample.ConsoleApp.UnitTests
{
    using System;
    using System.Linq;
    using Castle.Core.Logging;
    using Castle.Windsor;
    using FakeItEasy;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class GenericServiceTests
    {
        public class ExampleServiceContext : ContextSpecification
        {
            protected GenericService Sut;
            protected IWindsorContainer Container;
            protected ILogger Logger;

            protected override void Context()
            {
                base.Context();

                Logger = A.Fake<ILogger>();
                Container = new WindsorContainer();
                Sut = new GenericService(Container, Logger);
            }
        }

        [TestClass]
        public class WhenTheServiceHasBeenStarted : ExampleServiceContext
        {
            private string loggedMessage;
            private Func<Type[]> registeredServices;

            protected override void Context()
            {
                base.Context();

                A.CallTo(() => Logger.Debug(A<string>.Ignored))
                 .Invokes(call => loggedMessage = (string)call.Arguments[0]);

                registeredServices = () => Container.GetImplementationTypesFor<IWcfService>();
            }

            protected override void BecauseOf()
            {
                Sut.Start();
            }

            [TestMethod]
            public void ItShouldRegisterTheWcfService()
            {
                registeredServices().Any(type => type == typeof(MyWcfService)).Should().BeTrue();
            }

            [TestMethod]
            public void ItShouldLogAMessage()
            {
                loggedMessage.Should().Be("The service was started.");
            }
        }
        
        [TestClass]
        public class WhenTheServiceIsStopped : ExampleServiceContext
        {
            private string loggedMessage;

            protected override void Context()
            {
                base.Context();

                A.CallTo(() => Logger.Debug(A<string>.Ignored))
                 .Invokes(call => loggedMessage = (string)call.Arguments[0]);

                Sut.Start();
            }

            protected override void BecauseOf()
            {
                Sut.Stop();
            }

            [TestMethod]
            public void ItShouldLogAMessage()
            {
                loggedMessage.Should().Be("The service was stopped.");
            }
        }
    }
}