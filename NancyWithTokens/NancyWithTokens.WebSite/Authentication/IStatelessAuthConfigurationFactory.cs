using Nancy.Authentication.Stateless;

namespace NancyWithTokens.WebSite.Authentication
{
    public interface IStatelessAuthConfigurationFactory
    {
        StatelessAuthenticationConfiguration Create();
    }
}