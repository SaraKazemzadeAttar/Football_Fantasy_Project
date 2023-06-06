using System;
using SignUPAndLoginSection.DataAccessLayer;
using System;
using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection.presentationLayer
{
    public class login
    {
        public static void loginApi(password password, string email_username)
        {
            if (businessLayer.login.isUserRegistered(password, email_username))
            {
                businessLayer.login.generateToken(password, email_username); 
                // print main page of site (front)
            }
            else
            {
// tell user that login was not successful
            }
        }
    }

}
