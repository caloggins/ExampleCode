namespace NancyAspNetOwin.WebApp.Authentication
{
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;

    public class LoginModule : NancyModule
    {
        public LoginModule(UserData userData, ISecureTokenCreator secureTokenCreator)
        {
            this.RequiresHttps();

            Post["/login"] = p =>
            {
                var credentials = this.Bind<Credentials>();

                var user = userData.ValidateUser(credentials.UserName, credentials.Password);

                if (user is InvalidUser)
                    return HttpStatusCode.Unauthorized;

                var encodedToken = secureTokenCreator.CreateToken(user);
                return Response.AsJson(encodedToken);
            };
        }
    }
}