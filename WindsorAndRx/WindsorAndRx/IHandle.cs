namespace WindsorAndRx
{
    public interface IEventHandler
    {
        
    }

    public interface IHandle<in TEvent> : IEventHandler
        where TEvent : Event
    {
        void Handle(TEvent @event);
    }
}