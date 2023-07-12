using System.Text.RegularExpressions;
using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;
using System;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Security.AccessControl;

namespace SignUPAndLoginSection.presentationLayer;

public class User
{
    public string password { get; set; }
    public string fullName { get; set; }
    public int userId { get; set; }
    public string email { get; set; }
    public string mobilePhone { get; set; }
    public string userName { get; set; }
    public string OTPCode { get; set; }
    public bool isvalid { get; set; }
    public double cash { get; set; }
}

public static class SignUp
{
    public static businessLayer.User convertPres_UserToBusi_User(presentationLayer.User PU)
    {
        businessLayer.User BU = new businessLayer.User();

        UserName uv = new UserName(PU.userName);
        Email ev = new Email(PU.email);
        FullName fv = new FullName(PU.fullName);
        Password pv = new Password(PU.password);
        MobilePhone mv = new MobilePhone(PU.mobilePhone);


        BU.userName = uv;
        BU.email = ev;
        BU.fullname = fv;
        BU.password = pv;
        BU.mobilePhone = mv;

        return BU;
    }

    public static presentationLayer.User convertBusi_UserToPres_User(businessLayer.User BU)
    {
        presentationLayer.User PU = new presentationLayer.User();
        PU.userName = BU.userName.ToString();
        PU.email = BU.email.ToString();
        PU.fullName = BU.fullname.ToString();
        PU.password = BU.password.ToString();
        PU.mobilePhone = BU.mobilePhone.ToString();

        return PU;
    }

    public static IResult signUPAPI(presentationLayer.User input)
    {
        businessLayer.User u = new businessLayer.User();
        u = convertPres_UserToBusi_User(input);
        UserValidator user = new UserValidator(u);

        if (user.isValidUser)
        {
            bool emailExistence = businessLayer.checkEmail_Phone_Username.isEmailExist(u.email);
            bool phoneNumberExistence = businessLayer.checkEmail_Phone_Username.isPhoneExist(u.mobilePhone);
            bool userNameExistence = businessLayer.checkEmail_Phone_Username.isUsernameExist(u.userName);

            if (!emailExistence && !phoneNumberExistence && !userNameExistence)
            {
                presentationLayer.User u2 = new presentationLayer.User();
                u2 = convertBusi_UserToPres_User(u);
                string otp_code = OTP.GenerateRandomCode();
                u2.OTPCode = otp_code;
                OTP.send_code(u2);
                DataAccessLayer.UsersData.insertUserToDataBase(u2);
                return Results.Ok(new
                    {
                        message = "signUp was successful!"
                    }
                );
            }
            else
            {
                return Results.BadRequest(new
                    {
                        message = "information is not unique!"
                    }
                );
            }
        }
        else
        {
            if (!u.email.emailValidator(u.email.ToString()))
            {
                return Results.BadRequest(new
                    {
                        message = "emailErrorMassage"
                    }
                );
            }

            if (!u.userName.usernameValidator(u.userName.ToString()))
            {
                return Results.BadRequest(new
                    {
                        message = "userNameErrorMessage"
                    }
                );
            }

            if (!u.mobilePhone.mobilePhoneValidator(u.mobilePhone.ToString()))
            {
                return Results.BadRequest(new
                    {
                        message = "mobileErrorMessage"
                    }
                );
            }

            if (!u.password.passwordValidator(u.password.ToString()))
            {
                return Results.BadRequest(new
                    {
                        message = "passwordErrorMessage"
                    }
                );
            }

            if (!u.fullname.fullNameValidator(u.fullname.ToString()))
            {
                return Results.BadRequest(new
                    {
                        message = "fullNameErrorMassage"
                    }
                );
            }

            return Results.BadRequest(new
                {
                    message = "information is not valid that can not be found !"
                }
            );
        }
    }
}

public class UserName
{
    // public bool isValidUsername = false;
    public string userNameContext;
    public string userNameErrorMessage = "";
    public bool isContainLetters = true;
    private bool isContainDigits = false;
    private bool isContainDashOrUnderscore = false;
    private bool isDashOrUnderscoreInStart = false;
    private bool isDashOrUnderscoreInEnd = false;
    public int numberOfDash = 0;
    public int numberOfUnderscore = 0;

    public UserName(string un)
    {
        usernameValidator(un);
    }

    public bool checkingLetters(string un)
    {
        bool containsLetter = Regex.IsMatch(un, "[a-zA-Z]");

        if (containsLetter)
        {
            return isContainLetters;
        }
        else
        {
            isContainLetters = false;
            return false;
        }
    }

    public bool checkingDigits(string un)
    {
        foreach (char ch in un)
        {
            if (char.IsDigit(ch))
            {
                isContainDigits = true;
                return isContainDigits;
            }
        }

        return isContainDigits;
    }

    public bool checkingDashOrUnderscore(string un)
    {
        foreach (char ch in un)
        {
            if (ch == '-' || ch == '_')
            {
                isContainDashOrUnderscore = true;
                return isContainDashOrUnderscore;
            }
        }

        return isContainDashOrUnderscore;
    }

    public void numberOfDashAndUnderscore(string un)
    {
        if (isContainDashOrUnderscore)
        {
            foreach (char ch in un)
            {
                if (ch == '_')
                {
                    numberOfUnderscore++;
                }

                if (ch == '-')
                {
                    numberOfDash++;
                }
            }
        }

        return;
    }

    public bool checkingDashOrUnderscoreInStart(string un)
    {
        if (isContainDashOrUnderscore)
        {
            if (un.StartsWith("-") || un.StartsWith("_"))
            {
                isDashOrUnderscoreInStart = true;
                return isDashOrUnderscoreInStart;
            }
        }

        return isDashOrUnderscoreInStart;
    }

    public bool checkingDashOrUnderscoreInEnd(string un)
    {
        if (isContainDashOrUnderscore)
        {
            if (un.EndsWith("-") || un.EndsWith("_"))
            {
                isDashOrUnderscoreInEnd = true;
                return isDashOrUnderscoreInEnd;
            }
        }

        return isDashOrUnderscoreInEnd;
    }

    public void usernameProblemsHandler()
    {
        if (!isContainLetters)
        {
            userNameErrorMessage = "username must contain letters!";
            return;
        }

        if (!isContainDigits)
        {
            userNameErrorMessage = "username must contain digits!";
            return;
        }

        if (isDashOrUnderscoreInEnd)
        {
            userNameErrorMessage = "username shouldn't end with dash or underscore!";
            return;
        }

        if (isDashOrUnderscoreInStart)
        {
            userNameErrorMessage = "username shouldn't start with dash or underscore!";
            return;
        }

        if (numberOfDash >= 2)
        {
            userNameErrorMessage = "username must have Maximum 1 dash!";
            return;
        }

        if (numberOfUnderscore >= 2)
        {
            userNameErrorMessage = "username must have Maximum 1 underscore!";
            return;
        }
    }

    public bool usernameValidator(string un)
    {
        numberOfDashAndUnderscore(un);

        if ((checkingLetters(un)) && (checkingDigits(un)) && (checkingDashOrUnderscore(un)) &&
            (numberOfDash <= 1) && (numberOfUnderscore <= 1) && (!checkingDashOrUnderscoreInEnd(un)) &&
            (!checkingDashOrUnderscoreInStart(un)))
        {
            userNameContext = un;
            // isValidUsername = true;
            return true;
        }
        else
        {
            usernameProblemsHandler();
            return false;
        }
    }
}

public class Email
{
    //public bool isValidEmail = false;
    public string emailErrorMassage = "";

    public Email(string e)
    {
        emailValidator(e);
    }

    public bool emailValidator(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9._%+-]+(@gmail|@email|@yahoo)\.(com|co|ir)\b";

        if (string.IsNullOrEmpty(email))
        {
            emailErrorMassage = "Invalid email!";
            return false;
        }

        Regex regex = new Regex(emailPattern);
        return regex.IsMatch(email);
    }
}

public class FullName
{
    public string nameContext;

    //  public bool isValidFullName = false;
    private bool isContainLetters = false;
    public string fullNameErrorMassage = "";

    public bool checkingLetters(string fn)
    {
        foreach (char ch in fn)
        {
            if (char.IsLetter(ch))
            {
                isContainLetters = true;
            }
            else
            {
                isContainLetters = false;
                return isContainLetters;
            }
        }

        return isContainLetters;
    }

    public FullName(string fn)
    {
        fullNameValidator(fn);
    }

    public bool fullNameValidator(string fn)
    {
        if (checkingLetters(fn))
        {
            nameContext = fn;
            // isValidFullName = true;
            return true;
        }
        else
        {
            fullNameErrorMassage = "inValid fullName!";
            return false;
        }
    }
}

public class Password
{
    public string passwordContext;

    //public bool isValidPassword = false;
    public string passwordErrorMessage = "";
    private bool isContainUpperCaseLetters = false;
    private bool isContainLowerCaseLetters = false;
    private bool isContainLetters = false;
    private bool isContainDigits = false;
    private bool isContainSpecialCharacters = false;
    private bool isLengthEqualToEight = false;

    public Password(string pw)
    {
        passwordValidator(pw);
    }

    public bool checkingUpperCaseLetters(string pw)
    {
        foreach (char ch in pw)
        {
            if (char.IsUpper(ch))
            {
                isContainUpperCaseLetters = true;
                return isContainUpperCaseLetters;
            }
        }

        return isContainUpperCaseLetters;
    }

    public bool checkingLowerCaseLetters(string pw)
    {
        foreach (char ch in pw)
        {
            if (char.IsLower(ch))
            {
                isContainLowerCaseLetters = true;
                return isContainLowerCaseLetters;
            }
        }

        return isContainLowerCaseLetters;
    }

    public bool checkingLetters(string pw)
    {
        if (isContainLowerCaseLetters || isContainUpperCaseLetters)
        {
            isContainLetters = true;
            return isContainLetters;
        }

        return isContainLetters;
    }

    public bool checkingDigits(string pw)
    {
        foreach (char ch in pw)
        {
            if (char.IsDigit(ch))
            {
                isContainDigits = true;
                return isContainDigits;
            }
        }

        return isContainDigits;
    }

    public bool checkingSpecialCharacters(string pw)
    {
        string specialChars = "!@#$%&*-_/"; // list of special characters to check for
        foreach (char ch in specialChars)
        {
            if (pw.Contains(ch))
            {
                isContainSpecialCharacters = true;
                return isContainSpecialCharacters;
            }
        }

        return false;
    }

    public bool checkingLength(string pw)
    {
        if (pw.Length == 8)
        {
            isLengthEqualToEight = true;
            return isLengthEqualToEight;
        }

        return isLengthEqualToEight;
    }

    public void passwordProblemsHandler()
    {
        if (!isContainUpperCaseLetters)
        {
            passwordErrorMessage = "password must have uppercase letters!";
            return;
        }

        if (!isContainLowerCaseLetters)
        {
            passwordErrorMessage = "password must have lowercase letters!";
            return;
        }

        if (!isContainLetters)
        {
            passwordErrorMessage = "password must have letters!";
            return;
        }

        if (!isContainDigits)
        {
            passwordErrorMessage = "password must have digits!";
            return;
        }

        if (!isContainSpecialCharacters)
        {
            passwordErrorMessage = "password must have special characters!";
            return;
        }

        if (!isLengthEqualToEight)
        {
            passwordErrorMessage = "password must have 8 characters!";
            return;
        }
    }

    public bool passwordValidator(string pw)
    {
        checkingUpperCaseLetters(pw);
        checkingLowerCaseLetters(pw);
        checkingDigits(pw);
        checkingLetters(pw);
        checkingSpecialCharacters(pw);
        checkingLength(pw);

        if ((isContainUpperCaseLetters) && (isContainLowerCaseLetters) && (isContainLetters) && (isContainDigits) &&
            (isContainSpecialCharacters) && (isLengthEqualToEight))
        {
            passwordContext = pw;
            // isValidPassword = true;
            return true;
        }
        else
        {
            // isValidPassword = false;
            passwordProblemsHandler();
            return false;
        }
    }
}

public class MobilePhone
{
    public string mobilePhoneContext;

    public string mobileErrorMessage = "";

    // public bool isValidMobilePhone = false;
    public bool isContainDigits = true;
    public bool isStartsWithZeroAndNine = false;
    public bool isLengthEqualsToEleven = false;

    public MobilePhone(string pn)
    {
        mobilePhoneValidator(pn);
    }

    public bool checkingDigits(string pn)
    {
        foreach (char ch in pn)
        {
            if (!char.IsDigit(ch))
            {
                isContainDigits = false;
                return isContainDigits;
            }
        }

        return isContainDigits;
    }

    public bool checkingStartsWithZeroAndNine(string pn)
    {
        if (pn[0] == '0' && pn[1] == '9')
        {
            isStartsWithZeroAndNine = true;
            return isStartsWithZeroAndNine;
        }

        return isStartsWithZeroAndNine;
    }

    public bool checkingLengthEqualsToEleven(string pn)
    {
        if (pn.Length == 11)
        {
            isLengthEqualsToEleven = true;
            return isLengthEqualsToEleven;
        }

        return isLengthEqualsToEleven;
    }

    public void mobilePhoneProblemsHandler()
    {
        if (!isContainDigits)
        {
            mobileErrorMessage = "phone number must contain numbers!";
            return;
        }

        if (!isStartsWithZeroAndNine)
        {
            mobileErrorMessage = "phone number must start with 09 !";
            return;
        }

        if (!isLengthEqualsToEleven)
        {
            mobileErrorMessage = "phone number must have 11 digits!";
            return;
        }
    }

    public bool mobilePhoneValidator(string pn)
    {
        checkingDigits(pn);
        checkingStartsWithZeroAndNine(pn);
        checkingLengthEqualsToEleven(pn);

        if ((isStartsWithZeroAndNine) && (isLengthEqualsToEleven) && (isContainDigits))
        {
            mobilePhoneContext = pn;
            // isValidMobilePhone = true;
            return true;
        }
        else
        {
            // isValidMobilePhone = false;
            mobilePhoneProblemsHandler();
            return false;
        }
    }
}