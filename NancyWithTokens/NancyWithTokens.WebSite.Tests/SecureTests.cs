using System;
using FakeItEasy;
using FluentAssertions;
using JWT;
using Nancy;
using NUnit.Framework;
using Nancy.Testing;
using NancyWithTokens.WebSite.Authentication;

namespace NancyWithTokens.WebSite.Tests
{
    public class SecureTests
    {
        private const string ValidKey = "68C9B92E-EA60-4018-960A-9E8F0739DF5D";

        public class WhenTheRequestIsInsecure : SecureTests
        {
            [Test]
            public void ItShouldReturnTheCorrectResponseCode()
            {
                var browser = GetBrowser();

                var response = browser.Get("/secure", with => { with.HttpRequest(); });

                response.StatusCode.Should().Be(HttpStatusCode.SeeOther);
            }
        }

        public class WhenThereIsNoToken : SecureTests
        {
            [Test]
            public void ItShouldReturnTheCorrectResponseCode()
            {
                var browser = GetBrowser();

                var response = browser.Get("/secure", with => { with.HttpsRequest(); });

                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }

        public class WhenTheTokenIsValid : SecureTests
        {
            [Test]
            public void ItShouldReturnTheCorrectStatusCode()
            {
                var browser = GetBrowser();

                var jwt = GetToken();
                var token = JsonWebToken.Encode(jwt, ValidKey, JwtHashAlgorithm.HS512);

                var response = browser.Get("/secure", with =>
                {
                    with.HttpsRequest();
                    with.Header("Authorization", token);
                });

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        public class WhenTheTokenHasExpired : SecureTests
        {
            [Test]
            public void ItShouldReturnTheCorrectStatusCode()
            {
                var browser = GetBrowser();

                var jwt = GetToken();
                jwt.Expiration = DateTime.UtcNow.AddDays(-1);

                var token = JsonWebToken.Encode(jwt, ValidKey, JwtHashAlgorithm.HS512);

                var response = browser.Get("/secure", with =>
                {
                    with.HttpsRequest();
                    with.Header("Authorization", token);
                });

                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }

        public class WhenTheTokenAudienceIsNotCorrect : SecureTests
        {
            [Test]
            public void ItShouldReturnTheCorrectStatusCode()
            {
                var browser = GetBrowser();

                var jwt = GetToken();
                jwt.Audience = "bad audience";
                var token = JsonWebToken.Encode(jwt, ValidKey, JwtHashAlgorithm.HS512);

                var response = browser.Get("/secure", with =>
                {
                    with.HttpsRequest();
                    with.Header("Authorization", token);
                });

                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }

        public class WhenTheTokenIssuerIsNotCorrect : SecureTests
        {
            [Test]
            public void ItShouldReturnTheCorrectStatusCode()
            {
                var browser = GetBrowser();

                var jwt = GetToken();
                jwt.Issuer = "bad issuer";
                var token = JsonWebToken.Encode(jwt, ValidKey, JwtHashAlgorithm.HS512);

                var response = browser.Get("/secure", with =>
                {
                    with.HttpsRequest();
                    with.Header("Authorization", token);
                });

                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }

        public class WhenTheUserDoesNotExist : SecureTests
        {
            [Test]
            public void ItShouldReturnTheCorrectStatusCode()
            {
                var browser = GetBrowser();

                var jwt = GetToken();
                jwt.Name = "nowhere man";
                var token = JsonWebToken.Encode(jwt, ValidKey, JwtHashAlgorithm.HS512);

                var response = browser.Get("/secure", with =>
                {
                    with.HttpsRequest();
                    with.Header("Authorization", token);
                });

                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }

        }

        public class WhenTheTokenEncryptionKeyIsIncorrect : SecureTests
        {
            [Test]
            public void ItShouldReturnTheCorrectStatusCode()
            {
                var browser = GetBrowser();
                var jwt = GetToken();
                const string invalidKey = "923B6905-C60D-4486-AF89-ABB250A182DF";
                var token = JsonWebToken.Encode(jwt, invalidKey, JwtHashAlgorithm.HS512);

                var response = browser.Get("/secure", with =>
                {
                    with.HttpsRequest();
                    with.Header("Authorization", token);
                });

                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            }
        }

        public class WhenTheEndpointNeedsClaims : SecureTests
        {
            [Test]
            public void ItShouldDenyAccessWithNoClaims()
            {
                var browser = GetBrowser();
                var jwt = GetToken();
                var token = JsonWebToken.Encode(jwt, ValidKey, JwtHashAlgorithm.HS512);

                var response = browser.Get("/needsclaim", with =>
                {
                    with.HttpsRequest();
                    with.Header("Authorization", token);
                });

                response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
            }

            [Test]
            public void ItShouldAllowAccessWithClaim()
            {
                var browser = GetBrowser();
                var jwt = GetToken();
                jwt.Roles = new[] { Claim.Admin };
                var token = JsonWebToken.Encode(jwt, ValidKey, JwtHashAlgorithm.HS512);

                var response = browser.Get("/needsclaim", with =>
                {
                    with.HttpsRequest();
                    with.Header("Authorization", token);
                });

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        private static Browser GetBrowser()
        {
            var keyProvider = A.Fake<IJwtKeyProvider>();
            A.CallTo(() => keyProvider.Audience)
                .Returns("audience");
            A.CallTo(() => keyProvider.Issuer)
                .Returns("issuer");
            A.CallTo(() => keyProvider.Key)
                .Returns(ValidKey);

            var bootstrap = new TestBootstrapper(container => { container.Register(keyProvider); });
            return new Browser(bootstrap);
        }

        private static Jwt GetToken()
        {
            return new Jwt
            {
                Audience = "audience",
                Issuer = "issuer",
                Expiration = DateTime.UtcNow.AddYears(10),
                Name = "Joe Dirt",
                Roles = new string[] { }
            };
        }
    }
}