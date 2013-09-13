namespace BrokerLibrary
{
    using System;
    using System.Configuration;

    using EasyNetQ;

    public static class BusFactory
    {
        public static IBus Create()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["rabbit"];

            if (connectionStringSettings == null || string.IsNullOrWhiteSpace(connectionStringSettings.ConnectionString))
                throw new InvalidOperationException("A connection string for the broker was not found. Please provide a connection string named 'rabbit.'");

            return RabbitHutch.CreateBus(connectionStringSettings.ConnectionString);
        }
    }
}