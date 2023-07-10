using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class profileOfUser
{
    public static string showUserName(User userprofile )
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (userprofile == user)
                    return user.fullName ;
            }
        }

        return null;
    }

    public static string showUserMobolePhone(User userprofile)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (userprofile == user)
                    return user.mobilePhone;
            }
        }
        return null;
    }

    public static string showUserEmail(User userprofile)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (userprofile == user)
                    return user.email;
            }
        }
        return null;
    }
    public static string showUserUserName(User userprofile)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (userprofile == user)
                    return user.userName;
            }
        }
        return null;
    }
    public static string showUserPassword(User userprofile)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (userprofile == user)
                    return user.password;
            }
        }
        return null;
    }

    public static string userProfile(User userprofile)
    {
        return showUserName(userprofile)+showUserMobolePhone(userprofile)+showUserEmail(userprofile)+
               showUserUserName(userprofile)+showUserPassword(userprofile);
        

    }
}