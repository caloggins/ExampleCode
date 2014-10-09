namespace ExampleApp
{
    public class FactoryExample : IExample
    {
        private readonly IServiceFactory serviceFactory;

        public FactoryExample(IServiceFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
        }

        public void Run()
        {
            var service = serviceFactory.Create();
            service.Print("* Factory example *");
            service.Print(@"Hello, world.");
            serviceFactory.Release(service);
        }
    }
}