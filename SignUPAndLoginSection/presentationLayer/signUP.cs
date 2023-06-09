using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class signUp
{
    public bool emailExistance = false;
    private bool phoneNumberExistance = false;
    private bool userNameExistance = false;
    private string ExistanceInDataBaseError = "";
    private string finalStatusOfSignUp = "";
    
        public void SignUpAPI(user u)
        {
            userValidator user = new userValidator(u);

            if (user.isValidUser)
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

                    finalStatusOfSignUp = "signUp was successful!";
                }
                else
                {
                    existanceProblemsHandler();
                }
            }
            else
            {
                finalStatusOfSignUp = user.validationErrorMessage;
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
                }
            }

            return emailExistance;
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
                    }
                }
            }

            return phoneNumberExistance;
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
                    }
                }
            }

            return userNameExistance;
        }
        
}
