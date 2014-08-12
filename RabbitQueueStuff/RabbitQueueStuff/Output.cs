namespace RabbitQueueStuff
{
    using System;

    public static class Output
    {
        private const string pressAnyKeyToContinue = "- Press any key to continue.- ";
        private const string pressAnyKeyToExit = "- Press any key to exit. -";

        public static void Pause()
        {
            DisplayAndPause(pressAnyKeyToContinue);
        }

        public static void MessageWithPause(string message)
        {
            var s = pressAnyKeyToContinue + Environment.NewLine + message;
            DisplayAndPause(s);
        }

        public static void Exit()
        {
            DisplayAndPause(pressAnyKeyToExit);
        }

        private static void DisplayAndPause(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}