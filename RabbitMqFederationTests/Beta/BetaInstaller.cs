namespace Beta
{
    using BrokerLibrary;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using EasyNetQ;

    public class BetaInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<Program>(),
                Component.For<Test>(),
                Component.For<IBus>().UsingFactoryMethod(BusFactory.Create)
                );
        }
    }
}