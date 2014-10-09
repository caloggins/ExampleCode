namespace ExampleApp
{
    public interface IServiceFactory
    {
        IService Create();

        void Release(IService dead);
    }
}