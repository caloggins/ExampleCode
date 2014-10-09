namespace ExampleApp
{
    using System;

    using Castle.Core.Internal;

    public class Program
    {
        static void Main()
        {
            var container = ContainerFactory.Create();
            
            container.ResolveAll<IExample>()
                .ForEach(example => example.Run());

            Console.ReadKey();
        }
    }
}
