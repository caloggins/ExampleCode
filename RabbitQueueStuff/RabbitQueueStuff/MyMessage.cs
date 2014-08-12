namespace RabbitQueueStuff
{
    using System;

    using EasyNetQ;

    [Queue("MyMessageQueue", ExchangeName = "MyMessageExchange")]
    public class MyMessage
    {
        public DateTime CurrentTime { get; set; }
    }
}