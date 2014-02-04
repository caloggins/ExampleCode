namespace Federations.FooMessages
{
    using System;

    public class Stop : IMessage
    {
        public Guid Id { get; set; }
    }
}