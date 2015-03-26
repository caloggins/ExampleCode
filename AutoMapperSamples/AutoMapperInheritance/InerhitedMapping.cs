namespace AutoMapperInheritance
{
    using System;
    using AutoMapper;
    using FizzWare.NBuilder;
    using FluentAssertions;
    using NUnit.Framework;

    public class InerhitedMapping
    {
        [SetUp]
        public void SetUp()
        {
            Mapper.Reset();
            Mapper.CreateMap<Source, Target>();
        }

        [Test]
        public void ItShouldHaveAValidConfig()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void ItShouldCopyFirstToTarget()
        {
            var first = Builder<Source>.CreateNew().Build();

            var target = Mapper.Map<Target>(first);

            target.ShouldBeEquivalentTo(first);
        }
    }

    public interface Base
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }

    public class Source : Base
    {
        public DateTime Created { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Target
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
    }
}