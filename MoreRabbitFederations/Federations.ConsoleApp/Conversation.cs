namespace Federations.ConsoleApp
{
    using EasyNetQ;

    public class Conversation
    {
        public void Start()
        {
            var publishBus = RabbitHutch.CreateBus("");
            
            
            var subscriptionBus = RabbitHutch.CreateBus("");


        }
    }
}