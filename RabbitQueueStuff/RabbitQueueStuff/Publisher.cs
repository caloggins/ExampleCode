namespace RabbitQueueStuff
{
    using System;

    using EasyNetQ;

    public interface IPublisher
    {
        void SendMessage(DateTime dateTime);
    }

    public class Publisher : IPublisher
    {
        private readonly IBus bus;

        public Publisher(IBus bus)
        {
            this.bus = bus;
        }

        public void SendMessage(DateTime dateTime)
        {
            var message = new MyMessage { CurrentTime = dateTime };
            bus.Publish(message);
        }
    }
}