namespace RabbitQueueStuff
{
    using Castle.Core;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using EasyNetQ;

    public class QueueStuffInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IBus>().UsingFactoryMethod(RabbitHutch.CreateBus).LifestyleSingleton(),
                Types.FromThisAssembly().BasedOn<IPublisher>(),
                Types.FromThisAssembly().BasedOn<IStartable>(),
                Types.FromThisAssembly().BasedOn<IDemo>().WithServiceFromInterface()
                );
        }
    }
}