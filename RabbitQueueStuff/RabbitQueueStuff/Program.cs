namespace RabbitQueueStuff
{
    using System;

    public class Program
    {
        static void Main()
        {
            try
            {
                using (var container = WindsorFactory.Create())
                {
                    container.Resolve<IDemo>()
                        .Run();

                    Output.Pause();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine();
                Console.WriteLine(exception);
            }
            finally
            {
                Output.Exit();
            }
        }
    }
}
