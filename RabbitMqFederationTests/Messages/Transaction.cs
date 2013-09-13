namespace Messages
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;

    public abstract class Transaction
    {
        public Guid TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get { return GetType().Name; } }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(@"- Transaction -");

            foreach (var format in from PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this)
                                   let name = descriptor.Name
                                   let value = descriptor.GetValue(this)
                                   select string.Format("{0}={1}", name, value))
                builder.AppendLine(format);

            builder.AppendLine(@"- Transaction -");

            return builder.ToString();
        }
    }
}