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
        if (u.userName.usernameValidator(u.userName.ToString()) && u.email.emailValidator(u.email.ToString())&& u.fullname.fullNameValidator(u.fullname.ToString()) &&
            u.password.passwordValidator(u.password.ToString()) && u.mobilePhone.mobilePhoneValidator(u.mobilePhone.ToString()))
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
        if (!u.userName.usernameValidator(u.userName.ToString()))
        {
            validationErrorMessage = u.userName.userNameErrorMessage;
            return;
        }

        if (!u.email.emailValidator(u.email.ToString()))
        {
            validationErrorMessage = u.email.emailErrorMassage;
            return;
        }

        if (!u.mobilePhone.mobilePhoneValidator(u.mobilePhone.ToString()))
        {
            validationErrorMessage = u.mobilePhone.mobileErrorMessage;
            return;
        }

        if (!u.password.passwordValidator(u.password.ToString()))
        {
            validationErrorMessage = u.password.passwordErrorMessage;
            return;
        }

        if (!u.fullname.fullNameValidator(u.fullname.ToString()))
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

