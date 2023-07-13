namespace SignUPAndLoginSection.DataAccessLayer;

using System;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Security.AccessControl;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.DataAccessLayer;

public class logIn
{

    public static bool arePasswordAndUsernameSync(string userName_, string password_)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (userName_.Equals(user.userName))
                    if (password_.Equals(user.password))
                        return true;
            }
        }

        return false;
    }

    public static bool arePasswordAndEmailSync(string email_, string password)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (email_.Equals(user.email))
                    if (password.Equals(user.password))
                        return true;
            }
        }

        return false;
    }
}