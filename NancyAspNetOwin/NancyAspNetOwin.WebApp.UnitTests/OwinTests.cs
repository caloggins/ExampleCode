namespace NancyAspNetOwin.WebApp.UnitTests
{
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using FluentAssertions;
    using Microsoft.Owin.Testing;
    using NUnit.Framework;

    public class OwinTests
    {
        private const string BaseUrl = "https://localhost/health";

        public class WhenThereIsNoHeader : OwinTests
        {
            [Test]
            public async void ItShouldReturnTheCorrectStatusCode()
            {
                var client = UnauthorizedClient();

                var response = await client.GetAsync(BaseUrl);

                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }

        public class WhenPassedValidToken : OwinTests
        {
            [Test]
            public async void ItShouldReturnTheCorrectResponse()
            {
                var client = AuthorizedClient();

                var response = await client.GetAsync(BaseUrl);

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }

            [Test]
            public async void TheResponseShouldContainTheExpectedMessage()
            {
                var client = AuthorizedClient();

                var response = await client.GetAsync(BaseUrl);

                var responseContent = await response.Content.ReadAsStringAsync();
                responseContent.Should().Be("\"Hello, testuser\"");
            }
        }

        private static HttpClient UnauthorizedClient()
        {
            var client = TestServer.Create(builder => new Startup().Configuration(builder)).HttpClient;
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        private static HttpClient AuthorizedClient()
        {
            var client = TestServer.Create(builder => new Startup().Configuration(builder)).HttpClient;
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJJc3N1ZXIiOiJodHRwczovL2xvY2FsaG9zdCIsIkF1ZGllbmNlIjoiaHR0cHM6Ly9sb2NhbGhvc3QiLCJDbGFpbXMiOlt7Iklzc3VlciI6IkxPQ0FMIEFVVEhPUklUWSIsIk9yaWdpbmFsSXNzdWVyIjoiTE9DQUwgQVVUSE9SSVRZIiwiUHJvcGVydGllcyI6e30sIlN1YmplY3QiOm51bGwsIlR5cGUiOiJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiLCJWYWx1ZSI6ImFkbWluIiwiVmFsdWVUeXBlIjoiaHR0cDovL3d3dy53My5vcmcvMjAwMS9YTUxTY2hlbWEjc3RyaW5nIn0seyJJc3N1ZXIiOiJMT0NBTCBBVVRIT1JJVFkiLCJPcmlnaW5hbElzc3VlciI6IkxPQ0FMIEFVVEhPUklUWSIsIlByb3BlcnRpZXMiOnt9LCJTdWJqZWN0IjpudWxsLCJUeXBlIjoiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSIsIlZhbHVlIjoidGVzdHVzZXIiLCJWYWx1ZVR5cGUiOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxL1hNTFNjaGVtYSNzdHJpbmcifV0sIkV4cGlyeSI6IlwvRGF0ZSgxNDQ3Mjc0OTAwNzgwKVwvIn0.9DijhiJJ45yyibO4ScnqlJnKX80RR1dGk6gtDveU20I");

            return client;
        }
    }
}