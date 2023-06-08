namespace SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
public class signUp
{
    
    public  void signUpAPI(user u)
    {
        string ExistanceInDataBaseError = "";
        // if validUser == true -> check : is it new or repeated?
        //                                     if new -> save the user
        //                                     if repeated:
        //                                                 email repeated -> error message
        //                                                 mobile repeated -> error message
        //                                                 username repeated -> error message
        //  if validUser == false -> special error message must be returned 
        userValidator user = new userValidator(u);
        
        if (user.userValidating())
        {
            if (doesEmailExistBefore(u.email))
            {
                ExistanceInDataBaseError = "there is already an account with this email";
                return;
            }

            if (doesPhoneNumberExistBefore(u.mobilePhone))
            {
                ExistanceInDataBaseError = "there is already an account with this mobile phone";
                return;
            }

            if (doesUserNameExistBefore(u.username))
            {
                ExistanceInDataBaseError = "there is already an account with this username";
                return;
            }

            if (!doesEmailExistBefore(u.email) && !doesPhoneNumberExistBefore(u.mobilePhone) &&
                !doesUserNameExistBefore(u.username))
            {
                using (var db = new DataBase())
                {
                    db.userTable.Add(u);
                    db.SaveChanges();
                }
                return;
            }
        }
    }
    public bool doesEmailExistBefore(email email_)
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
    public bool doesPhoneNumberExistBefore(mobilePhone num_)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (num_.Equals(user.mobilePhone))
                    return true;
            }
        }

        return false;
    }

    public bool doesUserNameExistBefore(userName userName_) 
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (userName_.Equals(user.username))
                    return true;
            }
        }

        return false;
    }
}