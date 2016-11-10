using System;

namespace NancyWithTokens.WebSite.Authentication
{
    public class Jwt
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public DateTime Expiration { get; set; }
        public string[] Roles { get; set; }
        public string Name { get; set; }
    }
}