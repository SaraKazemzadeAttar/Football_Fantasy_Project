using System;
using SignUPAndLoginSection.DataAccessLayer;
namespace SignUPAndLoginSection.businessLayer;

public class userValidator
{
    public user u;
    public bool isValidUser = false;
    public string validationErrorMessage = "";

    public userValidator(user input)
    {
        u = input;
        // userValidating();
    }

    public void userValidating()
    {
        if (u.username.isValidUsername && u.email.isValidEmail && u.fullname.isValidFullName &&
            u.password.isValidPassword && u.mobilePhone.isValidMobilePhone)
        {
            isValidUser = true;
        }
        else
        {
            userValidationProblemsHandler();
        }
    }

    private void userValidationProblemsHandler()
    {
        if (!u.username.isValidUsername)
        {
            validationErrorMessage = u.username.userNameErrorMessage;
            return;
        }

        if (!u.email.isValidEmail)
        {
            validationErrorMessage = u.email.emailErrorMassage;
            return;
        }

        if (!u.mobilePhone.isValidMobilePhone)
        {
            validationErrorMessage = u.mobilePhone.moileErrorMessage;
            return;
        }

        if (!u.password.isValidPassword)
        {
            validationErrorMessage = u.password.passwordErrorMessage;
            return;
        }

        if (!u.fullname.isValidFullName)
        {
            validationErrorMessage = u.fullname.fullNameErrorMassage;
            return;
        }
    }
}