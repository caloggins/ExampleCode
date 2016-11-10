using Nancy;

namespace NancyWithTokens.WebSite
{
    public class Health : NancyModule
    {
        public Health()
        {
            Get["/health"] = o => HttpStatusCode.OK;
        }
    }
}