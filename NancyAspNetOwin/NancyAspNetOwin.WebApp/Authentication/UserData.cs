namespace NancyAspNetOwin.WebApp.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Nancy.Security;

    public class UserData
    {
        private readonly List<Tuple<string, string>> users = new List<Tuple<string, string>>();
        private readonly Dictionary<string, IEnumerable<string>> claims = new Dictionary<string, IEnumerable<string>>();

        public UserData()
        {
            users.Add(new Tuple<string, string>("testuser", "testuser"));
            claims.Add("testuser", new[] { "admin" });
        }

        public IUserIdentity ValidateUser(string userName, string password)
        {
            var user = users.FirstOrDefault(MatchUserAndPassword(userName, password));
            if (user == null)
                return new InvalidUser();

            return new ValidatedUser("testuser", claims["testuser"].ToList().AsReadOnly());
        }

        private static Func<Tuple<string, string>, bool> MatchUserAndPassword(string userName, string password)
        {
            return tuple => tuple.Item1 == userName && tuple.Item2 == password;
        }
    }
}