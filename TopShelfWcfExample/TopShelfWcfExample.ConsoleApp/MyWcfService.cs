namespace TopShelfWcfExample.ConsoleApp
{
    using MyBusinessLibrary;

    public class MyWcfService : IWcfService
    {
        private readonly NewGreetingWithNameCommand greetingWithNameCommand;

        public MyWcfService(NewGreetingWithNameCommand greetingWithNameCommand)
        {
            this.greetingWithNameCommand = greetingWithNameCommand;
        }

        public string Greet()
        {
            return "Hello, world.";
        }

        public string GetGrettingWithName(string name)
        {
            greetingWithNameCommand.Name = name;
            return greetingWithNameCommand.Execute();
        }
    }
}