namespace DapperExamples
{
    using System;
    using System.Collections.Generic;

    using DapperExtensions.Mapper;

    public class GrandParent : Entity<Guid>
    {
        public GrandParent()
        {
            Parents = new List<Parent>();
        }

        public string Name { get; set; }

        public List<Parent> Parents { get; set; }

        public void AddParent(Parent parent)
        {
            Parents.Add(parent);
            parent.ParentId = Id;
        }
    }

    public sealed class GrandParentMap : ClassMapper<GrandParent>
    {
        public GrandParentMap()
        {
            Table("GrandParents");
            Map(deadline => deadline.Id).Column("Id").Key(KeyType.Assigned);
            Map(parent => parent.Parents).Ignore();
            AutoMap();
        }
    }
}