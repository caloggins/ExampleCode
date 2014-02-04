namespace Federations.FooMessages
{
    using System;

    public class Start : IMessage
    {
        public Guid Id { get; set; }
    }
}