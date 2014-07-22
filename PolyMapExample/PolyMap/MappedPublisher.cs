namespace PolyMap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    public class MappedPublisher : IPublisher
    {
        private readonly IBus bus;
        private readonly IMappingEngine mappingEngine;
        private readonly Dictionary<Type,Action<Command>>  publishMap = new Dictionary<Type, Action<Command>>();

        public MappedPublisher(IBus bus, IMappingEngine mappingEngine)
        {
            this.bus = bus;
            this.mappingEngine = mappingEngine;

            publishMap.Add(typeof(Start), Publish<Started>);
            publishMap.Add(typeof(Stop), Publish<Stopped>);
        }

        public void Publish(Command command)
        {
            var publishAction = GetPublishAction(command.GetType());
            publishAction(command);
        }

        private Action<Command> GetPublishAction(Type commandType)
        {
            var publishAction = (from a in publishMap
                where commandType == a.Key
                select a.Value).Single();

            return publishAction;
        }

        private void Publish<TEvent>(Command command) where TEvent : Event
        {
            var toPublish = mappingEngine.DynamicMap<TEvent>(command);
            bus.Publish(toPublish);
        }
    }
}