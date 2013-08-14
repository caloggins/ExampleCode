namespace Subscriber
{
    using System;
    using System.Threading;

    using EasyNetQ;

    using Messages;

    public class DemoSubscriber
    {
        private readonly IBus bus;

        public DemoSubscriber(IBus bus)
        {
            this.bus = bus;
        }

        public void ListenForAMessage()
        {
            var done = false;

            bus.Subscribe<ExampleMessage>("subscriber", message =>
            {
                Console.WriteLine(message.Greeting);
                done = true;
            });

            SpinWait.SpinUntil(() => done);
        } 
    }
}