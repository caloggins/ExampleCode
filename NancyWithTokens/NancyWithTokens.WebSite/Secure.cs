using Nancy;
using Nancy.Security;
using NancyWithTokens.WebSite.Authentication;

namespace NancyWithTokens.WebSite
{
    public class Secure : NancyModule
    {
        public Secure()
        {
            this.RequiresHttps();
            this.RequiresAuthentication();

            Get["/secure"] = o => HttpStatusCode.OK;

            Get["/needsclaim"] = o =>
            {
                this.RequiresClaims(Claim.Admin);

                return HttpStatusCode.OK;
            };
        }
    }

}