namespace TopShelfWcfExample.ConsoleApp
{
    using System;
    using Castle.Facilities.Logging;
    using Castle.Facilities.WcfIntegration;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using EasyNetQ;

    public class MyInstaller : IWindsorInstaller
    {
        public Func<LoggerImplementation> GetLoggerImplementation = () => LoggerImplementation.NLog;

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(facility => facility.LogUsing(GetLoggerImplementation()))
                .AddFacility<WcfFacility>();

            container.Register(
                Component.For<IWindsorContainer>().Instance(container),
                Component.For<IGenericService>().ImplementedBy<GenericService>(),
                Component.For<IBus>().UsingFactoryMethod<IBus>(RabbitBusFactory.Create)
                );
        }
    }
}