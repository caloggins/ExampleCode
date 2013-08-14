namespace Publisher
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

                Console.WriteLine("Press a key to generate a message.");
                Console.ReadKey();

                var message = new ExampleMessage { Greeting = "Hello, world!" };
                using (var channel = bus.OpenPublishChannel())
                    channel.Publish(message);
            }
            catch (Exception exception)
            {
                var assemblyName = typeof(Program).AssemblyQualifiedName;

                if (!EventLog.SourceExists(assemblyName))
                {
                    EventLog.CreateEventSource(assemblyName, "Application");
                }

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
