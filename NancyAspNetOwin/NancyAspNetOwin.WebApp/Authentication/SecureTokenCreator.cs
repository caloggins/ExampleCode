namespace NancyAspNetOwin.WebApp.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using JWT;
    using Nancy.Security;

    public class SecureTokenCreator : ISecureTokenCreator
    {
        private const string SecretKey = "30ea254132194990837862e7d9a644c1";

        public string CreateToken(IUserIdentity user)
        {
            var claims = new List<Claim>(user.Claims.Select(c => new Claim(ClaimTypes.Role, c)))
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var token = new JwtToken
            {
                Issuer = "https://localhost",
                Audience = "https://localhost",
                Claims = claims,
                Expiry = DateTime.UtcNow.AddDays(1),
            };

            var encodedToken = JsonWebToken.Encode(token, SecretKey, JwtHashAlgorithm.HS512);
            return encodedToken;
        }
    }
}