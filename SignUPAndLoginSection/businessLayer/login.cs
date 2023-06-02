using System;
using SignUPAndLoginSection.DataAccessLayer;
using signUpSection.DataAccessLayer;

namespace SignUPAndLoginSection.businessLayer;

public class login
{
    public static bool isUserRegistered(password password, string x)
    {
        if (DataAccessLayer.logIn.arePasswordAndUsernameSync(x, password.passwordContext) || DataAccessLayer.logIn.arePasswordAndEmailSync(x,password.passwordContext))
        {
            return true;
        }

        return false;
    }
}