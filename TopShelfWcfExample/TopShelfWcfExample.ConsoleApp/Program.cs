namespace TopShelfWcfExample.ConsoleApp
{
    using System;
    using System.Diagnostics;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using Topshelf;

    public class Program
    {
        static void Main()
        {
            try
            {
                var container = ContainerFactory();

                RunTheHostFactory(container);
            }
            catch (Exception exception)
            {
                var assemblyName = typeof(Program).AssemblyQualifiedName;

                if (!EventLog.SourceExists(assemblyName))
                    EventLog.CreateEventSource(assemblyName, "Application");

                var log = new EventLog { Source = assemblyName };
                log.WriteEntry(string.Format("{0}", exception), EventLogEntryType.Error);
            }
        }

        private static void RunTheHostFactory(IWindsorContainer container)
        {
            HostFactory.Run(config =>
                {
                    config.Service<IGenericService>(settings =>
                        {
                            settings.ConstructUsing(hostSettings => container.Resolve<IGenericService>());
                            settings.WhenStarted(service => service.Start());
                            settings.WhenStopped(service =>
                                {
                                    service.Stop();
                                    container.Release(service);
                                    container.Dispose();
                                });
                            settings.WhenPaused(service => { });
                            settings.WhenContinued(service => { });
                        });

                    config.RunAsLocalSystem();

                    var serviceDescription = container.Resolve<ServiceDescription>();
                    config.SetDescription(serviceDescription.Description);
                    config.SetDisplayName(serviceDescription.DisplayName);
                    config.SetServiceName(serviceDescription.ServiceName);
                });
        }

        private static IWindsorContainer ContainerFactory()
        {
            var container = new WindsorContainer()
                .Install(Configuration.FromAppConfig())
                .Install(FromAssembly.This());

            return container;
        }
    }
}
