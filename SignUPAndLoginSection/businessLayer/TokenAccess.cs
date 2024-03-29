using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SignUPAndLoginSection.businessLayer;

public class TokenAccess
{
    public static string token { get; set; }
    public static  string generateToken(string password , string email_username)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("userTokenlsjdjsljljnbfkdkdjlhrbdjskfhhdjkkshf"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim("password", password.ToString()),
            new Claim("emailOrUsername", email_username),
        };
        var token = new JwtSecurityToken(
            issuer: "http://localhost:7005",
            audience: "http://localhost:7005",
            claims,
            signingCredentials: credentials
        );
        var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
        return stringToken;
    }

    public static string getEmailOrUsernameFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(token);
        var email_username = jsonToken.Claims.First(claim => claim.Type == "emailOrUsername").Value;
        return email_username;
    }
}