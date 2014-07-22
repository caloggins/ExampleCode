namespace PolyMap
{
    using AutoMapper;

    public class OverloadedAutomappingPublisher : IPublisher
    {
        private readonly IBus bus;
        private readonly IMappingEngine mappingEngine;

        public OverloadedAutomappingPublisher(IBus bus, IMappingEngine mappingEngine)
        {
            this.bus = bus;
            this.mappingEngine = mappingEngine;
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
            var @event = mappingEngine.DynamicMap<Started>(command);
            bus.Publish(@event);
        }

        private void Publish(Stop command)
        {
            var @event = mappingEngine.DynamicMap<Stopped>(command);
            bus.Publish(@event);
        }
    }
}