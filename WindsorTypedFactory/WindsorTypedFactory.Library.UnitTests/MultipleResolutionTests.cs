namespace WindsorTypedFactory.Library.UnitTests
{
    using Castle.Core.Internal;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using FluentAssertions;

    using NUnit.Framework;

    public class MultipleResolutionTests
    {
        [Test]
        public void ItShouldResolveAllHandlers()
        {
            var container = new WindsorContainer()
                .AddFacility<TypedFactoryFacility>()
                .Register(
                    Component.For<HandlerFactory>().AsFactory(),
                    Classes.FromAssemblyContaining<Command>().BasedOn(typeof(IHandle<>)).WithServiceFromInterface()
                );

            var factory = container.Resolve<HandlerFactory>();

            var expected = container.ResolveAll(typeof(IHandle<Start>));
            expected.Should().NotBeEmpty();

            var handlers = factory.GetAllHandlers<Start>();
            handlers.Should().BeEquivalentTo(expected);

            handlers.ForEach(factory.Release);
        }
    }
}