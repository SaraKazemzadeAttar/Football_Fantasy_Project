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
    public  static bool isTokenActive = false;
    public static bool isUserRegistered(password password, string email_username)
    {
        if (DataAccessLayer.logIn.arePasswordAndUsernameSync(email_username, password.passwordContext) || DataAccessLayer.logIn.arePasswordAndEmailSync(email_username,password.passwordContext))
        {
            return true;
        }

        return false;
    }

    public static JwtSecurityToken generateToken(password password , string email_username)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("userTokenlsjdjsljljnbfkdkdjlhrbdjskfhhdjkkshf"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim("password", password.ToString()),
            new Claim("emailOrusername", email_username),
        };
        var token = new JwtSecurityToken(
            issuer: "http://localhost:3001",
            audience: "http://localhost:3001",
            claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );
        setTokenActive();
        return token;
    }

    public static  void setTokenActive()
    {
        isTokenActive = true;
    }
}