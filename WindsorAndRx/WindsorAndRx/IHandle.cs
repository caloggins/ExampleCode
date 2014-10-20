namespace WindsorAndRx
{
    public interface IHandle
    {
        
    }

    public interface IHandle<in TEvent> : IHandle
        where TEvent : Event
    {
        void Handle(TEvent @event);
    }
}