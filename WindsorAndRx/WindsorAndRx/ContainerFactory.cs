namespace WindsorAndRx
{
    using Castle.Facilities.Logging;
    using Castle.Facilities.Startable;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public static class ContainerFactory
    {
        public static IWindsorContainer Create()
        {
            var container = new WindsorContainer();

            container.AddFacility<StartableFacility>()
                .AddFacility<LoggingFacility>(facility => facility.UseNLog());

            container.Install(
                FromAssembly.This(),
                Configuration.FromAppConfig()
                );

            return container;
        }
    }
}