namespace PolyMap
{
    using AutoMapper;

    public class OverloadedAutomappingPublisher
    {
        private readonly IBus bus;
        private readonly IMappingEngine mappingEngine;

        public OverloadedAutomappingPublisher(IBus bus, IMappingEngine mappingEngine)
        {
            this.bus = bus;
            this.mappingEngine = mappingEngine;
        }

        public void Publish(Start command)
        {
            var @event = mappingEngine.DynamicMap<Started>(command);
            bus.Publish(@event);
        }

        public void Publish(Stop command)
        {
            var @event = mappingEngine.DynamicMap<Stopped>(command);
            bus.Publish(@event);
        }
    }
}