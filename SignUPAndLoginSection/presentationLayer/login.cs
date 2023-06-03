using System;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class login
{
    public void loginAPI(password password , string email_username)
    {
        
        if (businessLayer.login.isUserRegistered(password, email_username))
        {
            businessLayer.login.generateToken(password, email_username);
        }
        else
        {
            // tell error
        }
            
    }
}


