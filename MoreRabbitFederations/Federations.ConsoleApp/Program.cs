namespace Federations.ConsoleApp
{
    using System;

    using Properties;

    public class Program
    {
        public static void Main()
        {
            try
            {
                RunConversation();
            }
            catch (Exception exception)
            {
                DisplayException(exception);
            }
            finally
            {
                DisplayExitPrompt();
            }
        }

        private static void RunConversation()
        {
            var container = WindsorFactory.Create();
            var conversation = container.Resolve<Conversation>();
            conversation.Start();
        }

        private static void DisplayException(Exception exception)
        {
            Console.WriteLine();
            Console.WriteLine(exception);
        }

        private static void DisplayExitPrompt()
        {
            Console.WriteLine();
            Console.WriteLine(Resources.ExitMessage);
            Console.ReadKey();
        }
    }
}
