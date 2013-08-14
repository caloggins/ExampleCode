namespace Subscriber
{
    using System;
    using System.Diagnostics;

    using EasyNetQ;

    using Messages;

    public class Program
    {
        static void Main()
        {
            IBus bus = null;

            try
            {
                bus = BusFactory.Create();

                bus.Subscribe<ExampleMessage>("subscriber", message => Console.WriteLine(message.Greeting));
            }
            catch (Exception exception)
            {
                var assemblyName = typeof(Program).AssemblyQualifiedName;

                if (!EventLog.SourceExists(assemblyName))
                    EventLog.CreateEventSource(assemblyName, "Application");

                var log = new EventLog { Source = assemblyName };
                log.WriteEntry(string.Format("{0}", exception), EventLogEntryType.Error);
            }
            finally
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();

                if (bus != null)
                    bus.Dispose();
            }
        }
    }
}
