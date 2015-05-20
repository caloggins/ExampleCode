namespace StaticContentExample
{
    using Nancy;

    public class Home : NancyModule
    {
        public Home()
        {
            Get["/"] = _ => View["index.html"];
        }
    }
}