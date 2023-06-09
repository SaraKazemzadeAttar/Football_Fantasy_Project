using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class signUp
{
    private bool emailExistance;
    private bool phoneNumberExistance;
    private bool userNameExistance;
    private string ExistanceInDataBaseError = "";

    // if validUser == true -> check : is it new or repeated?
        //                                     if new -> save the user
        //                                     if repeated:
        //                                                 email repeated -> error message
        //                                                 mobile repeated -> error message
        //                                                 username repeated -> error message
        //  if validUser == false -> special error message must be returned 
        public void SignUpAPI(user u)
        {
            userValidator user = new userValidator(u);

            if (user.userValidating())
            {
                doesEmailExistBefore(u.email);
                doesPhoneNumberExistBefore(u.mobilePhone);
                doesUserNameExistBefore(u.username);
                if (!emailExistance && !phoneNumberExistance && !userNameExistance)
                {
                    using (var db = new DataBase())
                    {
                        db.userTable.Add(u);
                        db.SaveChanges();
                    }
                }
                else
                {
                    existanceProblemsHandler();
                }
            }
            else
            {
                // the reason why user is not valid must be shown ...?!
            }
        }

        public void existanceProblemsHandler()
        {
            if (emailExistance)
            {
                ExistanceInDataBaseError = "There is an account with this email already";
                return;
            }

            if (userNameExistance)
            {
                ExistanceInDataBaseError = "There is an account with this username already";
                return;
            }

            if (phoneNumberExistance)
            {
                ExistanceInDataBaseError = "There is an account with this phone number already";
                return;
            }
        }

        public bool doesEmailExistBefore(email email_)
        {
            using (var db = new DataBase())
            {
                foreach (var user in db.userTable)
                {
                    if (email_.Equals(user.email))
                        emailExistance = true;
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
                    {
                        phoneNumberExistance = true;
                        return true;
                    }
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
                    {
                        userNameExistance = true;
                        return true;
                    }
                }
            }

            return false;
        }
}