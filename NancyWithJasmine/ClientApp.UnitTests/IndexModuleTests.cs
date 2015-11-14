namespace ClientApp.UnitTests
{
    using FluentAssertions;
    using Nancy;
    using Nancy.Testing;
    using NUnit.Framework;

    public class IndexModuleTests
    {
        private Browser browser;

        [SetUp]
        public void SetUp()
        {
            browser = new Browser(with =>
           {
               with.Module<IndexModule>();
               with.ViewFactory<TestingViewFactory>();
           }, with =>
           {
               with.HttpsRequest();
           });
        }
        public class WhenTheDefaultRootIsCalled : IndexModuleTests
        {
            [Test]
            public void ItShouldReturnTheCorrectView()
            {
                var response = GetResponse();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }

            [Test]
            public void ItShouldReturnTheCorrectPage()
            {
                var response = GetResponse();

                response.GetViewName().Should().Be("index");
            }

            private BrowserResponse GetResponse()
            {
                return browser.Get("/");
            }
        }
    }
}