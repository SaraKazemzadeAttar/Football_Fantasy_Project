using System;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection.businessLayer;

public class User
{
    public int userId;
    public UserName userName;
    public Email email;
    public FullName fullname;
    public Password password;
    public MobilePhone mobilePhone;
    public static bool isvalid;
}


public class checkEmail_Phone_Username
{
    public static bool isEmailExist(string e)
    {
        if (DataAccessLayer.UsersData.doesEmailExistBefore(e))
        {
            return true;
        }

        return false;
    }

    public static bool isPhoneExist(string m)
    {
        if (DataAccessLayer.UsersData.doesPhoneNumberExistBefore(m))
        {
            return true;
        }

        return false;
    }

    public static bool isUsernameExist(string un)
    {
        if (DataAccessLayer.UsersData.doesUserNameExistBefore(un))
        {
            return true;
        }

        return false;
    }
}