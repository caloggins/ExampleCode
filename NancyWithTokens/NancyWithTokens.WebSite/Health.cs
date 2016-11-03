using Nancy;

namespace NancyWithTokens.WebSite
{
    public class Health : NancyModule
    {
        public Health()
        {
            Get["/"] = o => HttpStatusCode.OK;
        }
    }
}