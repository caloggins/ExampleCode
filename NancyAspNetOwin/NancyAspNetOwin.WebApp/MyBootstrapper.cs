namespace NancyAspNetOwin.WebApp
{
    using System.Linq;
    using System.Security.Claims;
    using Authentication;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Conventions;
    using Nancy.Owin;
    using Nancy.TinyIoc;

    public class MyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            var owinEnvironment = context.GetOwinEnvironment();

            if (owinEnvironment == null)
                return;

            var principal = owinEnvironment["server.User"] as ClaimsPrincipal;

            if (principal == null) return;

            var userName = principal.Identity.Name;
            var claims = principal.Claims.Where(
                o => o.Type == ClaimTypes.Role)
                .Select(o => o.Value);
            context.CurrentUser = new ValidatedUser(userName, claims);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions
                .Add(StaticContentConventionBuilder.AddDirectory("App", @"App"));
            nancyConventions.StaticContentsConventions
                .Add(StaticContentConventionBuilder.AddDirectory("fonts", @"fonts"));
            nancyConventions.StaticContentsConventions
                .Add(StaticContentConventionBuilder.AddDirectory("Scripts", @"Scripts"));
        }
    }
}