namespace Federations.BarConsole
{
    using System;

    using BarMessages;

    using EasyNetQ;

    using FooMessages;

    public class Bar
    {
        private readonly IBus bus;

        public Bar(IBus bus)
        {
            this.bus = bus;
        }

        public void DoIt()
        {
            bus.Subscribe<Start>("bar", message =>
            {
                Console.WriteLine("Start received: {0}", message.Id);
                bus.Publish(new Started { Id = message.Id });
            });

            bus.Subscribe<Stop>("bar", message =>
            {
                Console.WriteLine("Stop received: {0}", message.Id);
                bus.Publish(new Stopped { Id = message.Id });
            });
        }
    }
}