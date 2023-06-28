using System.Text.RegularExpressions;
using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;
using System;
using System.Security.Principal;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Security.AccessControl;
using System.Security.Policy;
using SignUPAndLoginSection.DataAccessLayer;
using User = SignUPAndLoginSection.businessLayer.User;

namespace SignUPAndLoginSection.DataAccessLayer;

public class UsersData
{
    public static bool doesEmailExistBefore(Email email_)
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

    public static bool doesPhoneNumberExistBefore(MobilePhone num_)
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

        return false;
    }

    public static bool doesUserNameExistBefore(UserName userName_)
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

    public static void setInitialCashForUser(presentationLayer.User u)
    {
        u.cash = 100;
    }

    public static void insertUserToDataBase(presentationLayer.User u)
    {
        using (var db = new DataBase())
        {
            setInitialCashForUser(u);
            db.userTable.Add(u);
            db.SaveChanges();
        }
    }

    public static presentationLayer.User FindUserByTheirToken(string token)
    {
        var e_un = TokenAccess.getEmailOrUsernameFromToken(token);
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (e_un == user.userName || e_un == user.email)
                {
                    return user;
                }
            }
        }

        return null;
    }

    public static List<string> createListOfUsernames()
    { 
        List<string> userNamesList = new List<string>();
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                string u = user.userName;
                userNamesList.Add(u);
            }
        }

        return userNamesList;
    }
}