namespace WindsorAndRx
{
    using System;

    class Program
    {
        static void Main()
        {
            try
            {
                using (var container = ContainerFactory.Create())
                {
                    var publisher = container.Resolve<Publisher>();
                    publisher.DoIt("Hello, world.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
