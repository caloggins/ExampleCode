namespace DapperExamples
{
    using System;

    using DapperExtensions.Mapper;

    public class Child : Entity<Guid>
    {
        public Guid ParentId { get; set; }

        public string Name { get; set; }
    }

    public sealed class ChildMap : ClassMapper<Child>
    {
        public ChildMap()
        {
            Table("Children");
            Map(deadline => deadline.Id).Column("Id").Key(KeyType.Assigned);
            Map(child => child.ParentId);
            AutoMap();
        }
    }
}