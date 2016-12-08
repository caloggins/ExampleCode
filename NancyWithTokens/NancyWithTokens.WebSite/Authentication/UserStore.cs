namespace NancyWithTokens.WebSite.Authentication
{
    public class UserStore : IUserStore
    {
        public bool IsUserValid(string userName)
        {
            return userName.Equals("Joe Dirt");
        }
    }
}