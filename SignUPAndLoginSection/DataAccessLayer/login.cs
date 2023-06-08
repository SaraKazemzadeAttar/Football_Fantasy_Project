namespace SignUPAndLoginSection.DataAccessLayer;

using System;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Security.AccessControl;
using SignUPAndLoginSection.DataAccessLayer;

public class logIn
{

    public static bool arePasswordAndUsernameSync(string userName_, string password_)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (userName_.Equals(user.username))
                    if (password_.Equals(user.password))
                        return true;
            }
        }

        return false;
    }

    public static bool arePasswordAndEmailSync(string userName_, string email_)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (email_.Equals(user.email))
                    if (userName_.Equals(user.username))
                        return true;
            }
        }

        return false;
    }
}