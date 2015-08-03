namespace NancyAspNetOwin.WebApp
{
    using Nancy;

    public class Index : NancyModule
    {
        public Index()
        {
            Get["/"] = p => View["index"];
        }
    }
}