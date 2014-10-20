namespace WindsorAndRx
{
    using System;

    using Castle.Facilities.Startable;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using MemBus;

    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IWindsorContainer>().Instance(container),
                Component.For<IBus, IPublisher>().UsingFactoryMethod(MemoryBus.Create).LifeStyle.Singleton,
                Component.For<IObservable<Event>>().UsingFactoryMethod(MemoryBus.CreateObservable<Event>).LifeStyle.Singleton,
                Component.For<Publisher>().LifeStyle.Singleton,
                Component.For<Distributor>().LifeStyle.Singleton.Start(),
                Classes.FromThisAssembly().BasedOn(typeof(IHandle<>)).WithService.AllInterfaces()
                );
        }
    }
}