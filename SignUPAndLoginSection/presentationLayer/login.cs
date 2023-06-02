using System;
using signUpSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class login
{
    public void logInAPI(password password , string x)
    {
        if (businessLayer.login.isUserRegistered(password, x))
        {
            // token in business
        }
        else
        {
            // tell error
        }
            
    }
}
