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
        private readonly IUserStore userStore;

        public StatelessAuthConfigurationFactory(IJwtKeyProvider keyProvider, IUserStore userStore)
        {
            this.keyProvider = keyProvider;
            this.userStore = userStore;
        }

        public StatelessAuthenticationConfiguration Create()
        {
            return new StatelessAuthenticationConfiguration(VerifyToken);
        }

        private IUserIdentity VerifyToken(NancyContext context)
        {
            var encryptedToken = context.Request.Headers.Authorization;

            if (ThereIsNoToken(encryptedToken))
                return null;

            var jwt = JsonWebToken.DecodeToObject<Jwt>(encryptedToken, keyProvider.Key);

            if (TheTokenIsExpired(jwt))
                return null;

            if (TheAudienceDoesNotMatch(keyProvider, jwt))
                return null;

            if (TheIssuerDoesNotMatch(keyProvider, jwt))
                return null;

            if (TheUserIsNotValid(jwt))
                return null;

            return new ValidUser(jwt);
        }

        private bool TheUserIsNotValid(Jwt jwt)
        {
            return !userStore.IsUserValid(jwt.Name);
        }

        private static bool TheIssuerDoesNotMatch(IJwtKeyProvider provider, Jwt jwt)
        {
            return !provider.Issuer.Equals(jwt.Issuer);
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