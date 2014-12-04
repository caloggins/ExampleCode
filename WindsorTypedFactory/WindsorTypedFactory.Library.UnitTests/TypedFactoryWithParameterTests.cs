namespace WindsorTypedFactory.Library.UnitTests
{
    using System;

    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using NUnit.Framework;

    public class TypedFactoryWithParameterTests
    {
        private string message;

        [Test]
        public void ExpectedBehavior()
        {
            var container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<ITypedFactoryWithParameter>().AsFactory(),
                Component.For<Doh>(),
                Component.For<Foo>()
                );

            var factory = container.Resolve<ITypedFactoryWithParameter>();
            message = "Hello, world.";
            var foo = factory.Create(new Bar(message));

            Assert.That(foo.GetMessage(), Is.EqualTo(message));
            Assert.That(foo.GetError(), Is.EqualTo("D'oh!"));
        }

        public interface ITypedFactoryWithParameter
        {
            Foo Create(Bar bar);

            void Release(Foo dead);
        }

        public class Foo
        {
            private readonly Doh doh;
            private readonly Bar bar;

            public Foo(Doh doh, Bar bar)
            {
                this.doh = doh;
                this.bar = bar;
            }

            public string GetMessage()
            {
                return bar.Message;
            }

            public string GetError()
            {
                return doh.Error;
            }
        }

        public class Doh
        {
            public string Error {get { return "D'oh!"; }}
        }

        public class Bar
        {

            public Bar(string message)
            {
                Message = message;
            }

            public string Message { get; private set; }
        }
    }
}