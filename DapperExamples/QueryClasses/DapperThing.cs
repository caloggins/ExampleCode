namespace QueryClasses
{
    using System;
    using DapperExtensions.Mapper;

    public class DapperThing : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid ClientKey { get; set; }
        public Guid EnrollmentKey { get; set; }
    }

    public sealed class DapperThingMap : ClassMapper<DapperThing>
    {
        public DapperThingMap()
        {
            Table("DapperStuff");

            Map(thing => thing.Id).Key(KeyType.Assigned);
            AutoMap();
        }
    }
}