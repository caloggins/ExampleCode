namespace NancyAspNetOwin.WebApp
{
    using Authentication;
    using Microsoft.Owin.Extensions;
    using Owin;
    using Owin.StatelessAuth;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var pathsToIgnore = new[]
            {
                "/",
                "/app/**/*.js",
                "/app/**/*.html",
                "/login",
                "/content",
                "/content/*.*",
                "/fonts/*.*",
                "/scripts/*.js",
            };

            app.RequiresStatelessAuth(new SecureTokenValidator(),
                    new StatelessAuthOptions { IgnorePaths = pathsToIgnore });
            app.UseNancy();
            app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}