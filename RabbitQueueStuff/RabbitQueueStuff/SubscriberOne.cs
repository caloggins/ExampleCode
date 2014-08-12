namespace RabbitQueueStuff
{
    using System;
    using System.Threading.Tasks;

    using Castle.Core;

    using EasyNetQ;

    public class SubscriberOne : IStartable
    {
        private readonly IBus bus;
        private IDisposable subscription;

        public SubscriberOne(IBus bus)
        {
            this.bus = bus;
        }

        public void Start()
        {
            subscription = bus.SubscribeAsync<MyMessage>(GetType().Name, Process, configuration => configuration.WithAutoDelete());
        }

        private async Task Process(MyMessage message)
        {
            await Task.Factory.StartNew(() => Console.WriteLine("Message received: {0}", message.CurrentTime));
        }

        public void Stop()
        {
            subscription.Dispose();
        }
    }
}