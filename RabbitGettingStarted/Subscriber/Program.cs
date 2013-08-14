namespace Subscriber
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
                program.DoASubscription();
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

        private void DoASubscription()
        {
            var bus = BusFactory.Create();

            try
            {
                var subscriber = new DemoSubscriber(bus);
                subscriber.ListenForAMessage();

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
            finally
            {
                bus.Dispose();                
            }
        }
    }
}
