namespace ExampleApp
{
    public class HandlerExample : IExample
    {
        private readonly IService service;

        public HandlerExample(IService service)
        {
            this.service = service;
        }

        public void Run()
        {
            service.Print(@"* Handler Example *");
            service.Print(@"Hello, world.");
        }
    }
}