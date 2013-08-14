namespace Publisher
{
    using EasyNetQ;

    using Messages;

    public class DemoPublisher
    {
        private readonly IBus bus;

        public DemoPublisher(IBus bus)
        {
            this.bus = bus;
        }

        public void Publish()
        {
            var message = new ExampleMessage { Greeting = "Hello, world!" };

            using (var channel = bus.OpenPublishChannel())
                channel.Publish(message);
        }
    }
}