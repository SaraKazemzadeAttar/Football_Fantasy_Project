using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SignUPAndLoginSection.businessLayer;

public class login
{
    public static bool isUserRegistered(string password, string email_username)
    {
        if (logIn.arePasswordAndUsernameSync(email_username, password) ||logIn.arePasswordAndEmailSync(email_username,password))
        {
            return true;
        }
        return false;
    }
}