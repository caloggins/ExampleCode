namespace Publisher
{
    using System;
    using System.Diagnostics;

    public class Program
    {
        static void Main()
        {
            try
            {
                var program = new Program();

                program.WaitToSendAMessage();

                program.SendAMessage();
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
            }
        }

        private void SendAMessage()
        {
            var bus = BusFactory.Create();
            
            var publisher = new DemoPublisher(bus);
            publisher.Publish();

            bus.Dispose();
        }

        private void WaitToSendAMessage()
        {
            Console.WriteLine("Press a key to generate a message.");
            Console.ReadKey();
        }
    }
}
