using System;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class login
{
    public void logInAPI(password password , string x)
    {
        
        if (businessLayer.login.isUserRegistered(password, x))
        {
            
        }
        else
        {
            // tell error
        }
            
    }
}
