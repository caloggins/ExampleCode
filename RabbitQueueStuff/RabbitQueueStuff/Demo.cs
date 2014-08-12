namespace RabbitQueueStuff
{
    using System;

    using EasyNetQ;

    public interface IDemo
    {
        void Run();
    }

    public class Demo : IDemo
    {
        private readonly IBus bus;

        public Demo(IBus bus)
        {
            this.bus = bus;
        }

        public void Run()
        {
            Output.MessageWithPause("Ready to publish a message.");

            var message = new MyMessage{CurrentTime = DateTime.UtcNow};
            bus.Publish(message);
        } 
    }
}