﻿namespace Federations.BarConsole
{
    using System;

    using BrokerLibrary;

    using Properties;

    public class Program
    {
        static void Main()
        {
            try
            {
                var bus = BusFactory.Create();

                var bar = new Bar(bus);
                bar.DoIt();

                Console.ReadKey();

                bus.Dispose();
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
