namespace WindsorTypedFactory.Library.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;

    using Castle.Core.Internal;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using FluentAssertions;

    using NUnit.Framework;

    public class GenericTypedFactoryTests
    {

        [Test]
        public void GenericTypedFactory()
        {
            var container = new WindsorContainer()
                .AddFacility<TypedFactoryFacility>()
                .Register(
                    Component.For(typeof(IGenericFactory<>)).AsFactory(),
                    Classes.FromThisAssembly().BasedOn<Startable>().WithServiceFromInterface()
                );

            var factory = container.Resolve<IGenericFactory<Startable>>();

            var startables = factory.Resolve().ToList();

            startables.Should().HaveCount(2);

            startables.ForEach(factory.Release);
        }

    }

    public interface IGenericFactory<T>
    {
        IEnumerable<T> Resolve();

        void Release(T dead);
    }

    public interface Startable
    {
        
    }

    public class First : Startable
    {
        
    }

    public class Second : Startable
    {
        
    }
}