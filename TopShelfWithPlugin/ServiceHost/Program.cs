namespace ServiceHost
{
    using System;
    using System.Diagnostics;

    using Adapter;

    using Castle.Facilities.Logging;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using Topshelf;

    class Program
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

        private static IWindsorContainer ContainerFactory()
        {
            return new WindsorContainer()
                .AddFacility<LoggingFacility>(facility => facility.LogUsing(LoggerImplementation.NLog))
                .Install(Configuration.FromAppConfig())
                .Install(FromAssembly.This())
                .Install(FromAssembly.InDirectory(new AssemblyFilter("plugins")));
        }

        private static void RunTheHostFactory(IWindsorContainer container)
        {
            HostFactory.Run(config =>
            {
                config.Service<IHostedService>(settings =>
                {
                    settings.ConstructUsing(hostSettings =>
                    {
                        var service = container.Resolve<IHostedService>();
                        return service;
                    });
                    settings.WhenStarted(service => service.Start());
                    settings.WhenStopped(service =>
                    {
                        service.Stop();
                        container.Release(service);
                        container.Dispose();
                    });
                    settings.WhenPaused(service => service.Pause());
                    settings.WhenContinued(service => service.Continue());
                });

                config.BeforeInstall(() =>
                {
                });
                config.AfterUninstall(() =>
                {
                });

                config.RunAsLocalSystem();

                var serviceDescription = container.Resolve<ServiceDescription>();
                config.SetDescription(serviceDescription.Description);
                config.SetDisplayName(serviceDescription.DisplayName);
                config.SetServiceName(serviceDescription.ServiceName);

                config.DependsOnEventLog();
            });
        }
    }
}
