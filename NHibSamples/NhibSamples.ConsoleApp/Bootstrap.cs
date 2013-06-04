namespace NhibSamples.ConsoleApp
{
    using Castle.Facilities.Logging;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using DataAccess;
    using NHibernate;

    public class Bootstrap
    {
        public string ConnectionString { get; set; }

        public void InitializeContainer(IWindsorContainer container)
        {
            container.AddFacility<LoggingFacility>(facility => facility.LogUsing(LoggerImplementation.Null));

            container.Register(
                Component.For<IHazRun>().ImplementedBy<Program>(),
                Component.For<ISessionFactoryFactory>().ImplementedBy<SessionFactoryFactory>().LifeStyle.Singleton,
                Component.For<ISessionFactory>().UsingFactoryMethod(
                    () => container.Resolve<ISessionFactoryFactory>().CreateSessionFactory(ConnectionString))
                );
        } 
    }
}