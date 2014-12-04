namespace WindsorTypedFactory.Library.UnitTests
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using FluentAssertions;

    using NUnit.Framework;

    public class ResolvingGenericsTests
    {

        [Test]
        public void ItShouldResolveShit()
        {
            var container = new WindsorContainer();
            container.Register(
                Component.For<MyService>(),
                Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>))
                );

            var myService = container.Resolve<MyService>();

            myService.Should().NotBeNull();
        }

        public interface IRepository<T> where T : class
        {
            T Get();

            void Save(T t);
        }

        public class Repository<T> : IRepository<T> where T : class
        {
            public T Get()
            {
                return null;
            }

            public void Save(T t)
            {
            }
        }

        public class MyService
        {
            public MyService(IRepository<Thing> repository)
            {

            }
        }

        public class Thing
        {
        }
    }
}