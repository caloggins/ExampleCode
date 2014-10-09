namespace ExampleApp
{
    using System;

    public class NewService : IService
    {
        public void Print(string message)
        {
            Console.WriteLine("New Service: {0}", message);
        }
    }
}