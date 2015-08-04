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
        }
    }
}