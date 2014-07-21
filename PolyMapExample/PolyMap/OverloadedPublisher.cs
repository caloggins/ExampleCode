namespace PolyMap
{
    public class OverloadedPublisher
    {
        private readonly IBus bus;

        public OverloadedPublisher(IBus bus)
        {
            this.bus = bus;
        }

        public void Publish(Start command)
        {
            bus.Publish(new Started { Id = command.Id });
        }

        public void Publish(Stop command)
        {
            bus.Publish(new Stopped { Id = command.Id });
        }
    }
}