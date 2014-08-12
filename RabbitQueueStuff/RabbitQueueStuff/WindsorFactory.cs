namespace RabbitQueueStuff
{
    using Castle.Facilities.Logging;
    using Castle.Facilities.Startable;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public class WindsorFactory
    {
        public static IWindsorContainer Create()
        {
            var container = new WindsorContainer();

            container
                .AddFacility<LoggingFacility>(facility => facility.UseNLog())
                .AddFacility<StartableFacility>(facility => facility.DeferredStart());

            container.Install(
                FromAssembly.This()
                );

            return container;
        }
    }
}