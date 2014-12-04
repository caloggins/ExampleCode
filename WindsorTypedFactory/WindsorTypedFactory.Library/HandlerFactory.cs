namespace WindsorTypedFactory.Library
{
    public interface HandlerFactory
    {
        IHandle<T>[] GetAllHandlers<T>()
            where T : Command;

        void Release<T>(IHandle<T> dead)
            where T : Command;
    }
}