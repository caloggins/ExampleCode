namespace ExampleApp
{
    using System;

    public class OldService : IService
    {
        public void Print(string message)
        {
            Console.WriteLine("Old Service: {0}", message);
        }
    }
}