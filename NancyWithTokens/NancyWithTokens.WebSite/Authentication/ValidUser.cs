using System.Collections.Generic;
using Nancy.Security;

namespace NancyWithTokens.WebSite.Authentication
{
    public class ValidUser : IUserIdentity
    {
        public ValidUser(Jwt token)
        {
            UserName = token.Name;
            Claims = token.Roles;
        }

        public string UserName { get; }

        public IEnumerable<string> Claims { get; }
    }
}