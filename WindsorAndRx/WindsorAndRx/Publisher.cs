namespace WindsorAndRx
{
    using MemBus;

    public class Publisher
    {
        private readonly IPublisher events;

        public Publisher(IPublisher events)
        {
            this.events = events;
        }

        public void DoIt(string message)
        {
            var @event = new DidIt { Messsage = message };
            events.Publish(@event);
        }
    }}