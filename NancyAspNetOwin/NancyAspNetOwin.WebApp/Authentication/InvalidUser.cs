namespace NancyAspNetOwin.WebApp.Authentication
{
    using System.Collections.Generic;
    using Nancy.Security;

    public class InvalidUser : IUserIdentity
    {
        public string UserName { get; private set; }
        public IEnumerable<string> Claims { get; private set; }
    }
}