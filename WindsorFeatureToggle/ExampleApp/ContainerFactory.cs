namespace ExampleApp
{
    using Castle.Core.Internal;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    public static class ContainerFactory
    {
        public static IWindsorContainer Create()
        {
            var container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new AppSettingsConvention());

            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Classes.FromThisAssembly().BasedOn<IHandlerSelector>().WithService.FromInterface(),
                Classes.FromThisAssembly().BasedOn<IService>().WithService.FromInterface(),
                Component.For<IServiceFactory>().AsFactory(configuration => configuration.SelectedWith<ServiceSelector>()),
                Component.For<ServiceSelector>(),
                Classes.FromThisAssembly().BasedOn<IExample>().WithService.FromInterface()
                );

            container.ResolveAll<IHandlerSelector>()
                .ForEach(selector => container.Kernel.AddHandlerSelector(selector));

            return container;
        }
    }
}