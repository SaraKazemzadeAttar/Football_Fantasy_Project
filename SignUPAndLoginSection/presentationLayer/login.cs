using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer
{
    public class login
    {
        public static IResult loginApi(string password, string email_username)
        {
            if (businessLayer.login.isUserRegistered(password, email_username))//&& u.isvalid)
            {
                businessLayer.login.generateToken(password, email_username);
                return Results.Ok(new
                    {
                        message = "login was successful!"
                    }
                );
            }
            else
            {
                return Results.BadRequest(new
                    {
                        message = "login was not successful"
                    }
                );
                // print main page of site (front)
            }
        }
    }
}
