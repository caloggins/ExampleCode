namespace Federations.BarMessages
{
    using System;

    public class Started : IMessage
    {
        public Guid Id { get; set; }
    }
}