namespace NancyAspNetOwin.WebApp.UnitTests.Authentication
{
    using CsQuery.ExtensionMethods;
    using FakeItEasy;
    using FluentAssertions;
    using Nancy;
    using Nancy.Testing;
    using NUnit.Framework;
    using WebApp.Authentication;

    public class LoginModuleTests
    {
        private Browser browser;
        private ISecureTokenCreator secureTokenCreator;

        [SetUp]
        public void SetUp()
        {
            secureTokenCreator = A.Fake<ISecureTokenCreator>();

            browser = new Browser(with =>
            {
                with.Module<LoginModule>();
                with.Dependency<UserData>();
                with.Dependency(secureTokenCreator);
            });
        }
        public class WhenNoCredentialsAreGiven : LoginModuleTests
        {
            [Test]
            public void ItShouldReturnStatusCode()
            {
                var response = browser.Post("/login");

                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }

        public class WhenInvalidCredentialsAreGiven : LoginModuleTests
        {
            [Test]
            public void ItShouldReturnStatusCode()
            {
                var credentials = new Credentials { Password = "", UserName = "" };

                var response = browser.Post("/login", with =>
                {
                    with.Body(credentials.ToJSON());
                });

                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }

        public class WhenVAlidCredentialsAreGiven : LoginModuleTests
        {
            [Test]
            public void ItShouldReturnStatusCode()
            {
                var response = PostCredentials();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }

            [Test]
            public void ItShouldReturnAToken()
            {
                const string encodedToken = "encoded token";
                A.CallTo(() => secureTokenCreator.CreateToken(A<ValidatedUser>._))
                    .Returns(encodedToken);

                var result = PostCredentials()
                    .Body.DeserializeJson<string>();

                result.Should().Be(encodedToken);
            }

            private BrowserResponse PostCredentials()
            {
                var credentials = new Credentials { UserName = "testuser", Password = "testuser" };
                var response = browser.Post("/login", with => { with.JsonBody(credentials); });
                return response;
            }
        }
    }
}