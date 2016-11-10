using System.Configuration;

namespace NancyWithTokens.WebSite.Authentication
{

    public class JwtKeyProvider : IJwtKeyProvider
    {
        public string Audience => ConfigurationManager.AppSettings["audience"];
        public string Issuer => ConfigurationManager.AppSettings["issuer"];
        public string Key => ConfigurationManager.AppSettings["key"];
    }
}