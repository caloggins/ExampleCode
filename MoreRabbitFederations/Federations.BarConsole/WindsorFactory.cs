namespace Federations.BarConsole
{
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public static class WindsorFactory
    {
        public static IWindsorContainer Create()
        {
            var container = new WindsorContainer()
                .Install(
                    Configuration.FromAppConfig(),
                    FromAssembly.This()
                );

            return container;
        }
    }
}