namespace WindsorAndRx
{
    using System;
    using System.Collections;

    using Castle.Windsor;

    public class Distributor
    {
        private readonly IWindsorContainer container;

        public Distributor(IObservable<Event> events, IWindsorContainer container)
        {
            // Didn't use a factory, because it would just be fluff wrapping.
            // Exception to the rule of passing a container for me.
            this.container = container;
            events.Subscribe(ProcessEvent);
        }

        private void ProcessEvent(Event e)
        {
            var handlers = GetTheHandlers(e);

            HandleTheEvent(e, handlers);
        }

        private void HandleTheEvent(Event e, IEnumerable handlers)
        {
            // This also works for command handlers
            // difference is 1 handler for commands, multiple for events.
            foreach (dynamic handler in handlers)
            {
                handler.Handle((dynamic)e);
                container.Release(handler);
            }
        }

        private Array GetTheHandlers(Event e)
        {
            var handlerType = typeof(IHandle<>).MakeGenericType(e.GetType());
            var handlers = container.ResolveAll(handlerType);
            return handlers;
        }
    }
}