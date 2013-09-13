namespace Alpha
{
    using System;
    using System.Threading;

    using EasyNetQ;

    using FizzWare.NBuilder;

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
            Console.WriteLine("Press a key to send a message.");
            Console.ReadKey();

            PublishMessage<VisaTransaction>();
            PublishMessage<MasterCardTransaction>();

            SpinWait.SpinUntil(() => Console.ReadKey().Key == ConsoleKey.Escape);
        }

        private void PublishMessage<T>() where T : Transaction
        {
            var message = Builder<T>.CreateNew().Build();
            using (var channel = bus.OpenPublishChannel())
                channel.Publish(message, configuration => configuration.WithTopic(typeof(T).Name));
        }
    }
}