using System.Text.RegularExpressions;
using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;
using System;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Security.AccessControl;

namespace SignUPAndLoginSection.DataAccessLayer;


public partial class signUp
{

    public static bool doesEmailExistBefore(EmailValidation email_)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (email_.Equals(user.email))
                    return true;
            }
        }

        return false;
    }

    public static bool doesPhoneNumberExistBefore(MobilePhoneValidation num_)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (num_.Equals(user.mobilePhone))
                {
                    return true;
                }
            }
        }

        return false ;
    }

    public static bool doesUserNameExistBefore(UserNameValidation userName_)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (userName_.Equals(user.userName))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static void insertUserToDataBase(businessLayer.User u)
    {
        using (var db = new DataBase())
        {
            db.userTable.Add(u);
            db.SaveChanges();
        }
    }
}






