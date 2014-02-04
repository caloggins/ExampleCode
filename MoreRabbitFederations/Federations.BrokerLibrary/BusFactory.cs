namespace Federations.BrokerLibrary
{
    using System.Configuration;

    using EasyNetQ;

    public static class BusFactory
    {
        public static IBus Create()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["rabbit"].ConnectionString;

            return RabbitHutch.CreateBus(connectionString,
                register => register.Register<IEasyNetQLogger>(provider => new EasyNetNullLogger()));
        }
    }
}