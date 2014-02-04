namespace Federations.FooConsole
{
    using System;

    using BarMessages;

    using EasyNetQ;

    using FooMessages;

    public class Foo
    {
        private readonly IBus bus;

        public Foo(IBus bus)
        {
            this.bus = bus;
        }

        public void DoIt()
        {
            bus.Subscribe<Started>("foo", started =>
            {
                Console.WriteLine("Started received: {0}", started.Id);
                bus.Publish(new Stop { Id = started.Id });
            });

            bus.Subscribe<Stopped>("foo", stopped =>
            {
                Console.WriteLine("Stopped received: {0}", stopped.Id);
            });

            Console.WriteLine("press key to send message");
            Console.ReadKey();

            var start = new Start { Id = Guid.NewGuid() };
            bus.Publish(start);
        }
    }
}