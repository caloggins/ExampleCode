namespace PolyMap
{
    public class OverloadedPublisher : IPublisher
    {
        private readonly IBus bus;

        public OverloadedPublisher(IBus bus)
        {
            this.bus = bus;
        }

        public void Publish(Command command)
        {
            var commandType = command.GetType();

            if (commandType == typeof(Start))
                Publish((Start)command);

            if (commandType == typeof(Stop))
                Publish((Stop)command);
        }

        private void Publish(Start command)
        {
            bus.Publish(new Started { Id = command.Id });
        }

        private void Publish(Stop command)
        {
            bus.Publish(new Stopped { Id = command.Id });
        }
    }
}