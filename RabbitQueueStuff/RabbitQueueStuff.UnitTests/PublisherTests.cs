namespace RabbitQueueStuff.UnitTests
{
    using System;

    using EasyNetQ;

    using FakeItEasy;

    using FluentAssertions;

    using NUnit.Framework;

    public class PublisherTests
    {
        [Test]
        public void SendMessage_ShouldSendAMessage()
        {
            var sampleDate = new DateTime(2014, 1, 2);
            var fakeBus = A.Fake<IBus>();
            MyMessage publishedMessage = null;
            var expectedMessage = new MyMessage { CurrentTime = sampleDate };
            A.CallTo(() => fakeBus.Publish(A<MyMessage>._))
                .Invokes(call => publishedMessage = (MyMessage)call.Arguments[0]);

            var sut = new Publisher(fakeBus);

            sut.SendMessage(sampleDate);

            publishedMessage.ShouldBeEquivalentTo(expectedMessage);
        }
    }
}