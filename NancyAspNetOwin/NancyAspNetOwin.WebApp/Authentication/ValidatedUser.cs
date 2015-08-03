namespace NancyAspNetOwin.WebApp.Authentication
{
    using System.Collections.Generic;
    using Nancy.Security;

    public class ValidatedUser : IUserIdentity
    {
        public ValidatedUser(string userName, IEnumerable<string> claims)
        {
            UserName = userName;
            Claims = claims;
        }

        public string UserName { get; private set; }
        public IEnumerable<string> Claims { get; private set; }
    }
}