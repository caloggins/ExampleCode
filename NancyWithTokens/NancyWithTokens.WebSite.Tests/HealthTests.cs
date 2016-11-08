using FluentAssertions;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

namespace NancyWithTokens.WebSite.Tests
{
    public class HealthTests
    {
        [Test]
        public void ItShouldReturnTheCorrectStatusCode()
        {
            var browser = new Browser(with => { with.Module<Health>(); });

            var response = browser.Get("/health", with => { with.HttpsRequest(); });

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
