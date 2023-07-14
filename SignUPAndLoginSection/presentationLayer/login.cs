using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer
{
    public class login
    {
        public static IResult loginApi(string password, string email_username)
        {
            presentationLayer.User u = UsersData.findUserByTheirEmailOrUsername(email_username);
            if (businessLayer.login.isUserRegistered(password, email_username)&& u.isvalid)
            {
                businessLayer.TokenAccess.generateToken(password, email_username);
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
            }
        }
    }
}
