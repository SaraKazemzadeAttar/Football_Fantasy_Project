using System;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection.businessLayer;

public class User
{
    public int userId ;
    public UserNameValidation userName;
    public EmailValidation email;
    public FullNameValidation fullname;
    public PasswordValidation password;
    public MobilePhoneValidation mobilePhone;

}
public class UserValidator
{
    public businessLayer.User u = new businessLayer.User();
    public bool isValidUser = false;
    public string validationErrorMessage = "";
    
    public UserValidator (businessLayer.User input)
    {
        u = input;
        userValidating();
    }
    

    public void userValidating()
    {
        if (u.userName.isValidUsername && u.email.isValidEmail && u.fullname.isValidFullName &&
            u.password.isValidPassword && u.mobilePhone.isValidMobilePhone)
        {
            isValidUser = true;
        }
        else
        {
            userValidationProblemsHandler();
        }
    }

    public void userValidationProblemsHandler()
    {
        if (!u.userName.isValidUsername)
        {
            validationErrorMessage = u.userName.userNameErrorMessage;
            return;
        }

        if (!u.email.isValidEmail)
        {
            validationErrorMessage = u.email.emailErrorMassage;
            return;
        }

        if (!u.mobilePhone.isValidMobilePhone)
        {
            validationErrorMessage = u.mobilePhone.moibleErrorMessage;
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

