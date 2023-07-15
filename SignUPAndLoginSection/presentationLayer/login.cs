using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cmp;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer
{
    public class login
    {
        public static IResult loginApi(string password, string email_username)
        {
            presentationLayer.User u = UsersData.findUserByTheirEmailOrUsername(email_username);
            if (businessLayer.login.isUserRegistered(password, email_username))// && //u.isvalid)
            {
                var result =businessLayer.TokenAccess.generateToken(password, email_username).ToString();
                return Results.Ok(result);
            }
            else
            {
                return Results.BadRequest();
            }
        }
    }
        // [AllowAnonymous]
        // [HttpGet("Login")]
        // public IActionResult Login()
        // {
        //     return Challenge(new AuthenticationProperties
        //     {
        //         RedirectUri = $"{HttpContext.Request.PathBase.Value}/GetToken"
        //     }, OpenIdConnectDefaults.AuthenticationScheme);
        // }
        //
        // [Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
        // [HttpGet("GetToken")]
        // public IActionResult GetToken()
        // {
        //     var token = _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectDefaults.AuthenticationScheme, "id_token").Result;
        //
        //     return Ok(new
        //     {
        //         Token = token
        //     });
        // }
}
