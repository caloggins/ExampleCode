namespace PolyMap.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using FakeItEasy;

    using FluentAssertions;

    using NUnit.Framework;

    public class MappedPublisherTests
    {
        private MappedPublisher sut;
        private IBus fakeBus;
        private IMappingEngine mappingEngine;
        private List<Event> publishedEvents; 

        [SetUp]
        public void SetUp()
        {
            fakeBus = A.Fake<IBus>();

            publishedEvents = new List<Event>();
            A.CallTo(fakeBus)
                .Where(call => call.Method.Name == "Publish")
                .Invokes(call => publishedEvents.Add((Event)call.Arguments[0]));

            mappingEngine = Mapper.Engine;

            sut = new MappedPublisher(fakeBus, mappingEngine);
        }

        [Test]
        public void ItShouldHandleStart()
        {
            var sampleGuid = Guid.NewGuid();
            var sampleCommand = new Start { Id = sampleGuid };
            var expectedEvent = new Started { Id = sampleGuid };

            sut.Publish(sampleCommand);

            var publishedEvent = publishedEvents.Single(@event => @event.GetType() == typeof(Started));
            publishedEvent.Should().BeOfType<Started>();
            publishedEvent.ShouldBeEquivalentTo(expectedEvent);
        }

        [Test]
        public void ItShouldHandleStop()
        {
            var sampleGuid = Guid.NewGuid();
            var sampleCommand = new Stop { Id = sampleGuid };
            var expectedEvent = new Stopped { Id = sampleGuid };

            sut.Publish(sampleCommand);

            var publishedEvent = publishedEvents.Single(@event => @event.GetType() == typeof(Stopped));
            publishedEvent.ShouldBeEquivalentTo(expectedEvent);
        }
    }
}