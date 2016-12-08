namespace NancyWithTokens.WebSite.Authentication
{
    public interface IUserStore
    {
        bool IsUserValid(string userName);
    }
}