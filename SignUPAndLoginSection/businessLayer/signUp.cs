using System;
using SignUPAndLoginSection.DataAccessLayer;
namespace SignUPAndLoginSection.businessLayer;

public class userValidator
{
    public user u;
    public bool isValidUser = false;
    
    public userValidator(user input)
    {
        u = input;
        //userValidating();
    }

    public bool userValidating()
    {
        if (u.username.isValidUsername && u.email.isValidEmail && u.fullname.isValidFullName &&
            u.password.isValidPassword && u.mobilePhone.isValidMobilePhone)
        {
            isValidUser = true;
            return isValidUser;
        }

        return isValidUser;
    }
        

}
