namespace NancyWithTokens.WebSite.Authentication
{
    public interface IJwtKeyProvider
    {
        string Audience { get; }
        string Issuer { get; }
        string Key { get; }
    }
}