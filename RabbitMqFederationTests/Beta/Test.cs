namespace Beta
{
    using System;
    using System.Threading;

    using EasyNetQ;

    using Messages;

    public class Test
    {
        private readonly IBus bus;

        public Test(IBus bus)
        {
            this.bus = bus;
        }

        public void Run()
        {
            bus.Subscribe<VisaTransaction>("Beta", PrintTransaction, configuration => configuration.WithTopic(typeof(VisaTransaction).Name));
            bus.Subscribe<MasterCardTransaction>("Beta", PrintTransaction,
                                                 configuration => configuration.WithTopic(typeof(MasterCardTransaction).Name));

            SpinWait.SpinUntil(() => Console.ReadKey().Key == ConsoleKey.Escape);
        }

        private void PrintTransaction<T>(T transaction) where T : Transaction
        {
            Console.WriteLine(transaction);
        }
    }
}