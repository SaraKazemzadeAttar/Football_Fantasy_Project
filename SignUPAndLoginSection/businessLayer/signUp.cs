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
        else
        {
            if (u.username.userNameErrorMessage != "")
            {
                Console.WriteLine(u.username.userNameErrorMessage);
            }

            if (u.password.passwordErrorMessage != "")
            {
                Console.WriteLine(u.password.passwordErrorMessage);

            }

            if (u.mobilePhone.moileErrorMessage != "")
            {
                Console.WriteLine(u.mobilePhone.moileErrorMessage);

            }

            if (u.email.emailErrorMassage != "")
            {
                Console.WriteLine(u.email.emailErrorMassage);

            }

            if (u.fullname.fullNameErrorMassage != "")
            {
                Console.WriteLine(u.fullname.fullNameErrorMassage);

            }
        }

        return isValidUser;
    }
}
        


