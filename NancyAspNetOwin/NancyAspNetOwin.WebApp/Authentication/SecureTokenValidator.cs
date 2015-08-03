namespace NancyAspNetOwin.WebApp.Authentication
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Security.Claims;
    using JWT;
    using Owin.StatelessAuth;

    public class SecureTokenValidator : ITokenValidator
    {
        const string SecretKey = "30ea254132194990837862e7d9a644c1";

        public ClaimsPrincipal ValidateUser(string token)
        {
            try
            {
                var decodedtoken = JsonWebToken.DecodeToObject(token, SecretKey) as Dictionary<string, object>;
                if (decodedtoken == null)
                    return null;

                var jwttoken = new JwtToken
                {
                    Audience = (string)decodedtoken["Audience"],
                    Issuer = (string)decodedtoken["Issuer"],
                    Expiry = DateTime.Parse(decodedtoken["Expiry"].ToString()),
                };

                if (decodedtoken.ContainsKey("Claims"))
                {
                    var claims = new List<Claim>();

                    for (var i = 0; i < ((ArrayList)decodedtoken["Claims"]).Count; i++)
                    {
                        var type = ((Dictionary<string, object>)((ArrayList)decodedtoken["Claims"])[i])["Type"].ToString();
                        var value = ((Dictionary<string, object>)((ArrayList)decodedtoken["Claims"])[i])["Value"].ToString();
                        claims.Add(new Claim(type, value));
                    }

                    jwttoken.Claims = claims;
                }

                if (jwttoken.Expiry < DateTime.UtcNow)
                    return null;

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(jwttoken.Claims, "Token"));

                return claimsPrincipal;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}