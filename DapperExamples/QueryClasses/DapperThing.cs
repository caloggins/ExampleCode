namespace QueryClasses
{
    using System;
    using System.Text;
    using DapperExtensions.Mapper;

    public class DapperThing : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid SomeData { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public byte[] RowVersion { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append(string.Format("Thing ({0} - {1}): ", Id, RowVersion));
            builder.Append(string.Format("{0}", SomeData));

            return builder.ToString();
        }
    }

    public sealed class DapperThingMap : ClassMapper<DapperThing>
    {
        public DapperThingMap()
        {
            Table("DapperQueryClasses");

            Map(thing => thing.Id).Key(KeyType.Assigned);
            Map(thing => thing.RowVersion).Key(KeyType.NotAKey).ReadOnly();
            AutoMap();
        }
    }
}