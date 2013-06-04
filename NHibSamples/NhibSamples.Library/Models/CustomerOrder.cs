namespace NhibSamples.Library.Models
{
    using System;

    public class CustomerOrder
    {
        public virtual long OrderId { get; set; }
        public virtual string Comments { get; set; }
        public virtual DateTime DatePlaced { get; set; }
        public virtual byte[] Version { get; set; }

        public override string ToString()
        {
            return string.Format("Customer Order <Id: {0}, Date Placed: {1:MM/dd/yyyy}>", OrderId, DatePlaced);
        }
    }
}