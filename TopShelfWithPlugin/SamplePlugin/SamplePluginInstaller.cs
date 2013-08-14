namespace SamplePlugin
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using ServiceHost.Adapter;

    public class SamplePluginInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly().BasedOn<IHostedService>().WithServiceFromInterface()
                );
        }
    }
}