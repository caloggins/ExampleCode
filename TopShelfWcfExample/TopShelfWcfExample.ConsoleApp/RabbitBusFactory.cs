namespace TopShelfWcfExample.ConsoleApp
{
    using System.Configuration;
    using EasyNetQ;

    public static class RabbitBusFactory
    {
        public static IBus Create()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["rabbit"];

            if (connectionString == null || string.IsNullOrWhiteSpace(connectionString.ConnectionString))
                throw new MyConfigurationException("Rabbit bus connection string not found.");

            return RabbitHutch.CreateBus(connectionString.ConnectionString);
        }
    }
}