namespace NancyAspNetOwin.WebApp
{
    using Nancy;
    using Nancy.Security;

    public class Index : NancyModule
    {
        public Index()
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