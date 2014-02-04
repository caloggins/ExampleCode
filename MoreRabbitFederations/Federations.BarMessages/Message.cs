namespace Federations.BarMessages
{
    using System;

    public interface IMessage
    {
        Guid Id { get; set; }
    }
}