namespace SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.DataAccessLayer;
using System;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Security.AccessControl;

public class userName
{
        public bool isValidUsername = false;
        public string userNameContext;
        public string userNameErrorMessage;
        public bool isContainLetters = true;
        private bool isContainDigits = false;
        private bool isContainDashOrUnderscore = false;
        private bool isDashOrUnderscoreInStart = false;
        private bool isDashOrUnderscoreInEnd = false;
        public int numberOfDash = 0;
        public int numberOfUnderscore = 0;

        public userName(string un)
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
                isContainLetters=false;
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

        public bool chekingDashOrUnderscore(string un)
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

        public bool chekingDashOrUnderscoreInStart(string un)
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

        public bool chekingDashOrUnderscoreInEnd(string un)
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
                userNameErrorMessage= "username shouldn't end with dash or underscore!";
                return;
            }

            if (isDashOrUnderscoreInStart)
            {
                userNameErrorMessage= "username shouldn't start with dash or underscore!";
                return;
            }

            if (numberOfDash >= 2)
            {
                userNameErrorMessage= "username must have Maximum 1 dash!";
                return;
            }

            if (numberOfUnderscore >= 2)
            {
                userNameErrorMessage= "username must have Maximum 1 underscore!";
                return;
            }
        }
        public bool usernameValidator(string un)
        {
            numberOfDashAndUnderscore(un);

            if ((checkingLetters(un)) && (checkingDigits(un)) && (chekingDashOrUnderscore(un)) && 
                (numberOfDash <= 1) && (numberOfUnderscore <= 1)&&(!chekingDashOrUnderscoreInEnd(un))&& (!chekingDashOrUnderscoreInStart(un)))
            {
                userNameContext = un;
                isValidUsername = true;
                return isValidUsername;
            }
            else
            {
                isValidUsername = false;
                usernameProblemsHandler();
                return isValidUsername;
            }
        }
}

public class email
{
   
    public  bool isValidEmail = false;
    public string emailErrorMassage = "";
    public email(string e)
    {
        emailValidator(e);
    }
    public bool emailValidator(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9._%+-]+(@gmail|@email|@yahoo)\.(com|co|ir)\b";

        if (string.IsNullOrEmpty(email))
        {
            emailErrorMassage = "Invalid email!";
            return isValidEmail;
        }

        Regex regex = new Regex(emailPattern);
        return regex.IsMatch(email);
    }
}

public class fullName
{
    public string nameContext;
    public bool isValidFullName = false;
    private bool isContainLetters = false;
    public string fullNameErrorMassage = "";
    public bool chekingLetters(string fn)
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

    public fullName(string fn)
    {
        fullNAmeValidator(fn);
    }
        
    public bool fullNAmeValidator(string fn)
    {
        if (chekingLetters(fn))
        {
            nameContext = fn;
            isValidFullName = true;
            return isValidFullName;
        }
        else
        { 
            fullNameErrorMassage = "inValid fullName!";
            return isValidFullName;
        }
    }
}

public class password
{
        public string passwordContext;
        public bool isValidPassword = false;
        public string passwordErrorMessage;
        private bool isContainUpperCaseLetters = false;
        private bool isContainLowerCaseLetters = false;
        private bool isContainLetters = false;
        private bool isContainDigits = false;
        private bool isContainSpecialCharacters = false;
        private bool isLengthEqualToEight = false;

        public password(string str)
        {
            passwordValidation(str);
        }

        public bool checkingUpperCaseLetters(string str)
        {
            foreach (char ch in str)
            {
                if (char.IsUpper(ch))
                {
                    isContainUpperCaseLetters = true;
                    return isContainUpperCaseLetters;
                }
            }

            return isContainUpperCaseLetters;
        }

        public bool checkingLowerCaseLetters(string str)
        {
            foreach (char ch in str)
            {
                if (char.IsLower(ch))
                {
                    isContainLowerCaseLetters = true;
                    return isContainLowerCaseLetters;
                }
            }

            return isContainLowerCaseLetters;
        }

        public bool chekingLetters(string str)
        {
            if (isContainLowerCaseLetters || isContainUpperCaseLetters)
            {
                isContainLetters = true;
                return isContainLetters;
            }

            return isContainLetters;
        }

        public bool chekingDigits(string str)
        {
            foreach (char ch in str)
            {
                if (char.IsDigit(ch))
                {
                    isContainDigits = true;
                    return isContainDigits;
                }
            }

            return isContainDigits;
        }

        public bool chekingSpecialCharacters(string str)
        {
            string specialChars = "!@#$%&*-_/"; // list of special characters to check for
            foreach (char ch in specialChars)
            {
                if (str.Contains(ch))
                {
                    isContainSpecialCharacters = true;
                    return isContainSpecialCharacters;
                }
            }
            return isContainSpecialCharacters;
        }

        public bool chekingLength(string str)
        {
            if (str.Length == 8)
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
                passwordErrorMessage= "password must have uppercase letters!";
                return;
            }

            if (!isContainLowerCaseLetters)
            {
                passwordErrorMessage= "password must have lowercase letters!";
                return;
            }

            if (!isContainLetters)
            {
                passwordErrorMessage= "password must have letters!";
                return;
            }

            if (!isContainDigits)
            {
                passwordErrorMessage= "password must have digits!";
                return;
            }

            if (!isContainSpecialCharacters)
            {
                passwordErrorMessage= "password must have special characters!";
                return;
            }

            if (!isLengthEqualToEight)
            {
                passwordErrorMessage= "password must have 8 characters!";
                return;
            }
            
        }
        public bool passwordValidation(string str)
        {
            checkingUpperCaseLetters(str);
            checkingLowerCaseLetters(str);
            chekingDigits(str);
            chekingLetters(str);
            chekingSpecialCharacters(str);
            chekingLength(str);
            
            if ((isContainUpperCaseLetters) && (isContainLowerCaseLetters) && (isContainLetters) && (isContainDigits) &&
                (isContainSpecialCharacters) && (isLengthEqualToEight))
            {
                passwordContext = str;
                isValidPassword = true;
                return isValidPassword;
            }
            else
            {
                isValidPassword = false;
                passwordProblemsHandler();
                return isValidPassword;
            }
        }
    }

public class mobilePhone
{
        public string mobilePhoneContext;
        public string moileErrorMessage;
        public bool isValidMobilePhone = false;
        public bool isContainDigits = true;
        public bool isStartsWithZeroAndNine = false;
        public bool isLengthEqualsToEleven = false;

        public mobilePhone(string pn)
        {
            mobilePhoneValidator(pn);
        }
        public bool chekingDigits(string pn)
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

        public bool chekingStartsWithZeroAndNine(string pn)
        {
            if (pn[0] == '0' && pn[1] == '9')
            {
                isStartsWithZeroAndNine = true;
                return isStartsWithZeroAndNine;
            }

            return isStartsWithZeroAndNine;
        }

        public bool chekingLengthEqualsToEleven(string pn)
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
                moileErrorMessage= "phone number must contain numbers!";
                return;
            }

            if (!isStartsWithZeroAndNine)
            {
                moileErrorMessage= "phone number must start with 09 !";
                return;
            }

            if (!isLengthEqualsToEleven)
            {
                moileErrorMessage= "phone number must have 11 digits!";
                return;
            }
        }
        public bool mobilePhoneValidator(string pn)
        {
            chekingDigits(pn);
            chekingStartsWithZeroAndNine(pn);
            chekingLengthEqualsToEleven(pn);
            
            if ((isStartsWithZeroAndNine) && (isLengthEqualsToEleven) && (isContainDigits))
            {
                mobilePhoneContext = pn;
                isValidMobilePhone = true;
                return isValidMobilePhone;
            }
            else
            {
                isValidMobilePhone = false;
                mobilePhoneProblemsHandler();
                return isValidMobilePhone;
            }
           
        }
}


