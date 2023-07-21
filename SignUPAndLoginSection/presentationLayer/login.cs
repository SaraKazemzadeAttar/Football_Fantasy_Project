using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cmp;
using ServiceStack;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer
{
    public class login
    {
        public static IResult loginApi(string password, string email_username)
        {
            User u = UsersData.findUserByTheirEmailOrUsername(email_username);
            if (businessLayer.login.isUserRegistered(password, email_username)&& u.isvalid)
            {
                var token = businessLayer.TokenAccess.generateToken(password, email_username);
                businessLayer.TokenAccess.token = token;

               return Results.Ok(new
                   {
                       token=token
                   }
               );
            }
            else
            {
                return Results.BadRequest(new
                {
                    message="login failed!"
                }
                );
            }
        }
    }
}
