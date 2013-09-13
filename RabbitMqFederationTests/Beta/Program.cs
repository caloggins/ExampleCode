namespace Beta
{
    using System;
    using System.Diagnostics;

    using Castle.Facilities.Logging;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public class Program
    {
        static void Main()
        {
            try
            {
                var container = CreateContainer();

                var program = container.Resolve<Test>();
                program.Run();

                container.Dispose();
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

        public static IWindsorContainer CreateContainer()
        {
            var container = new WindsorContainer();

            container.AddFacility<LoggingFacility>(facility => facility.LogUsing(LoggerImplementation.NLog))
                     .Install(FromAssembly.This())
                     .Install(Configuration.FromAppConfig());

            return container;
        }
    }
}
