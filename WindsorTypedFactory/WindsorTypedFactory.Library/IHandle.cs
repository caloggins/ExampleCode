namespace WindsorTypedFactory.Library
{
    //public interface IHandle
    //{
        
    //}

    public interface IHandle<in T>
        where T : Command
    {
        void Handle(T command);
    }
}