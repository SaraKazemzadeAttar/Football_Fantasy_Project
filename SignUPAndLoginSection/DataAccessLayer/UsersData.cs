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
    public static bool doesEmailExistBefore(string email_)
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

    public static bool doesPhoneNumberExistBefore(string num_)
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

    public static bool doesUserNameExistBefore(string userName_)
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
    

    public static void insertUserToDataBase(presentationLayer.User u)
    {
        using (var db = new DataBase())
        {
            Cash.setInitialCashForUser(u);
            db.userTable.Add(u);
            db.SaveChanges();
        }
    }

    public static presentationLayer.User FindUserByTheirToken(string token)
    {
        var e_un = TokenAccess.getEmailOrUsernameFromToken(token);
        return findUserByTheirEmailOrUsername(e_un);
    }

    public static presentationLayer.User findUserByTheirEmailOrUsername(string e_un)
    {
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