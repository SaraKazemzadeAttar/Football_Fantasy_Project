using System;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection.businessLayer;

public class User
{
    public int userId ;
    public UserName userName;
    public Email email;
    public FullName fullname;
    public Password password;
    public MobilePhone mobilePhone;
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

public class checkEmail_Phone_Username
{
    public static bool isEmailExist(Email e)
    {
        if (DataAccessLayer.UsersData.doesEmailExistBefore(e))
        {
            return true;
        }

        return false;
    }

    public static bool isPhoneExist(MobilePhone m)
    {
        if (DataAccessLayer.UsersData.doesPhoneNumberExistBefore(m))
        {
            return true;
        }

        return false;
    }

    public static bool isUsernameExist(UserName un)
    {
        if (DataAccessLayer.UsersData.doesUserNameExistBefore(un))
        {
            return true;
        }

        return false;
    }
  
}

