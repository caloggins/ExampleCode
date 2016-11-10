using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using NancyWithTokens.WebSite.Authentication;

namespace NancyWithTokens.WebSite
{
    public class Bootstrap : DefaultNancyBootstrapper
    {

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            ConfigureStatelessAuth(container, pipelines);
        }

        private static void ConfigureStatelessAuth(TinyIoCContainer container, IPipelines pipelines)
        {
            var statelessAuthConfigurationFactory = container.Resolve<IStatelessAuthConfigurationFactory>();
            var configuration = statelessAuthConfigurationFactory.Create();

            StatelessAuthentication.Enable(pipelines, configuration);
        }
    }
}