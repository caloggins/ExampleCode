using System;
using JWT;
using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Security;

namespace NancyWithTokens.WebSite.Authentication
{
    public class StatelessAuthConfigurationFactory : IStatelessAuthConfigurationFactory
    {
        private readonly IJwtKeyProvider keyProvider;

        public StatelessAuthConfigurationFactory(IJwtKeyProvider keyProvider)
        {
            this.keyProvider = keyProvider;
        }

        public StatelessAuthenticationConfiguration Create()
        {
            return new StatelessAuthenticationConfiguration(CreateConfiguration);
        }

        private IUserIdentity CreateConfiguration(NancyContext context)
        {
            var encryptedToken = context.Request.Headers.Authorization;

            if (ThereIsNoToken(encryptedToken))
                return null;

            var jwt = JsonWebToken.DecodeToObject<Jwt>(encryptedToken, keyProvider.Key);

            if (TheTokenIsExpired(jwt))
                return null;

            if (TheAudienceDoesNotMatch(keyProvider, jwt))
                return null;

            if (!TheIssuerDoesNotMatch(keyProvider, jwt))
                return null;

            return new ValidUser(jwt);
        }

        private static bool TheIssuerDoesNotMatch(IJwtKeyProvider provider, Jwt jwt)
        {
            return provider.Issuer.Equals(jwt.Issuer);
        }

        private static bool TheAudienceDoesNotMatch(IJwtKeyProvider provider, Jwt jwt)
        {
            return !provider.Audience.Equals(jwt.Audience);
        }

        private static bool ThereIsNoToken(string encryptedToken)
        {
            return string.IsNullOrWhiteSpace(encryptedToken);
        }

        private static bool TheTokenIsExpired(Jwt jwt)
        {
            return jwt.Expiration < DateTime.UtcNow;
        }

    }
}