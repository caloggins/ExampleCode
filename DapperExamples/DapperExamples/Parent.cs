namespace DapperExamples
{
    using System;

    using DapperExtensions.Mapper;

    public class Parent : Entity<Guid>
    {
        public Guid ParentId { get; set; }

        public string Name { get; set; }
    }

    public sealed class ParentMap : ClassMapper<Parent>
    {
        public ParentMap()
        {
            Table("Parents");
            Map(deadline => deadline.Id).Column("Id").Key(KeyType.Assigned);
            AutoMap();
        }
    }
}