namespace Federations.BarMessages
{
    using System;

    public class Stopped : IMessage
    {
        public Guid Id { get; set; }
    }
}