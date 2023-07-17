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

    public static string showUserMobilePhone(User userprofile)
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
    public static double showUserCash(User userprofile)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (userprofile == user)
                    return user.cash;
            }
        }
        return -1;
    }
    
    public static double showUserPoints(User userprofile)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (userprofile == user)
                    return ScoreTable.scoreCalculation(user.userId);
            }
        }
        return -1;
    }

    public static string userProfile(User userprofile)
    {
        return showUserName(userprofile)+showUserMobilePhone(userprofile)+showUserEmail(userprofile)+
               showUserUserName(userprofile)+showUserCash(userprofile);
        

    }
}