namespace NancyAspNetOwin.WebApp.Authentication
{
    using JWT;
    using Nancy.Security;

    public interface ISecureTokenCreator
    {
        string CreateToken(IUserIdentity user);
    }
}