namespace NancyAspNetOwin.WebApp
{
    using Nancy;
    using Nancy.Security;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            this.RequiresHttps();

            Get["/"] = p => View["index"];

            Get["/health"] = p =>
            {
                this.RequiresAuthentication();

                var userName = Context.CurrentUser.UserName;
                return Response.AsJson("Hello, " + userName);
            };
        }
    }
} 