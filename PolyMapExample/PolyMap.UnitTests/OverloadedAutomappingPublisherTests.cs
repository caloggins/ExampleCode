namespace PolyMap.UnitTests
{
    using System;

    using AutoMapper;

    using FakeItEasy;

    using FluentAssertions;

    using NUnit.Framework;

    public class OverloadedAutomappingPublisherTests
    {
        private OverloadedAutomappingPublisher sut;
        private IBus fakeBus;
        private IMappingEngine mappingEngine;
        private Event publishedEvent;

        [SetUp]
        public void SetUp()
        {
            fakeBus = A.Fake<IBus>();
            A.CallTo(fakeBus)
                .Where(call => call.Method.Name == "Publish")
                .Invokes(call => publishedEvent = (Event)call.Arguments[0]);

            mappingEngine = Mapper.Engine;

            sut = new OverloadedAutomappingPublisher(fakeBus, mappingEngine);
        }

        [Test]
        public void ItShouldHandleStart()
        {
            var sampleGuid = Guid.NewGuid();
            var sampleCommand = new Start { Id = sampleGuid };
            var expectedEvent = new Started { Id = sampleGuid };

            sut.Publish(sampleCommand);

            publishedEvent.ShouldBeEquivalentTo(expectedEvent);
        }

        [Test]
        public void ItShouldHandleStop()
        {
            var sampleGuid = Guid.NewGuid();
            var sampleCommand = new Stop { Id = sampleGuid };
            var expectedEvent = new Stopped { Id = sampleGuid };

            sut.Publish(sampleCommand);

            publishedEvent.ShouldBeEquivalentTo(expectedEvent);
        }
    }
}