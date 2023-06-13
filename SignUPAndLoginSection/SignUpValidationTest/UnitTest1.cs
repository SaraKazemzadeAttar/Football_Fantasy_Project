using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUpTest;
using SignUPAndLoginSection;

public class program
{
    public class EmailTests
    {
        [Test]
        public void ValidEmail_ReturnsTrue()
        {
            string email = "example@gmail.com";
            Email emailObj = new Email(email);

            bool isValid = emailObj.isValidEmail;

            Assert.IsTrue(isValid);
        }

        [Test]
        public void InvalidEmail_ReturnsFalse()
        {
            string email = "invalid_email";
            Email emailObj = new Email(email);

            bool isValid = emailObj.isValidEmail;

            Assert.IsFalse(isValid);
        }

        [Test]
        public void EmptyEmail_ReturnsFalse()
        {
            string email = "";
            Email emailObj = new Email(email);

            bool isValid = emailObj.isValidEmail;
            string errorMessage = emailObj.emailErrorMassage;

            Assert.IsFalse(isValid);
            Assert.AreEqual("Invalid email!", errorMessage);
        }

    }

    public class UserNameTest
    {
        [Test]
        public void CheckingLetters_ValidUsernameWithLetters_ReturnsTrue()
        {
            string validUsername = "Sara1234";
            UserName user = new UserName(validUsername);

            bool result = user.checkingLetters(validUsername);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void CheckingLetters_InvalidUsernameWithoutLetters_ReturnsFalse()
        {
            string invalidUsername = "12345";
            UserName user = new UserName(invalidUsername);

            bool result = user.checkingLetters(invalidUsername);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void CheckingDigits_ValidUsernameWithDigits_ReturnsTrue()
        {
            string validUsername = "maneli123";
            UserName user = new UserName(validUsername);

            bool result = user.checkingDigits(validUsername);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void CheckingDigits_InvalidUsernameWithoutDigits_ReturnsFalse()
        {
            string invalidUsername = "reyhaneh"; 
            UserName user = new UserName(invalidUsername);

            bool result = user.checkingDigits(invalidUsername);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void ChekingDashOrUnderscore_ValidUsernameWithDashOrUnderscore_ReturnsTrue()
        {
            string validUsername = "qwe_doe";
            UserName user = new UserName(validUsername);

            bool result = user.chekingDashOrUnderscore(validUsername);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void ChekingDashOrUnderscore_InvalidUsernameWithoutDashOrUnderscore_ReturnsFalse()
        {
            string invalidUsername = "abcdef";
            UserName user = new userName(invalidUsername);

            bool result = user.chekingDashOrUnderscore(invalidUsername);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void NumberOfDashAndUnderscore_ValidUsernameWithDashAndUnderscore_CountsCorrectly()
        {
            string validUsername = "Ali_Ahmadi-123";
            UserName user = new UserName(validUsername);

            user.numberOfDashAndUnderscore(validUsername);

            Assert.AreEqual(1, user.numberOfUnderscore);
            Assert.AreEqual(1, user.numberOfDash);
        }

        [Test]
        public void NumberOfDashAndUnderscore_InvalidUsernameWithoutDashOrUnderscore_ReturnsZero()
        {
            string invalidUsername = "mohammadreza";
            UserName user = new UserName(invalidUsername);

            user.numberOfDashAndUnderscore(invalidUsername);

            Assert.AreEqual(0, user.numberOfUnderscore);
            Assert.AreEqual(0, user.numberOfDash);
        }

        [Test]
        public void ChekingDashOrUnderscoreInStart_And_CheckingLetters_ValidUsername_ReturnsTrue()
        {
            string validUsername = "asdf_dpe";
            UserName user = new UserName(validUsername);

            bool result1 = user.chekingDashOrUnderscoreInStart(validUsername);
            bool result2 = user.checkingLetters(validUsername);

            Assert.AreEqual(true, result1);
            Assert.AreEqual(true, result2);
        }

        [Test]
        public void ChekingDashOrUnderscoreInStart_And_CheckingLetters_InvalidUsername_ReturnsFalse()
        {
            string invalidUsername = "123_amirali";
            UserName user = new UserName(invalidUsername);

            bool result1 = user.chekingDashOrUnderscoreInStart(invalidUsername);
            bool result2 = user.checkingLetters(invalidUsername);

            Assert.AreEqual(false, result1);
            Assert.AreEqual(false, result2);
        }

        [Test]
        public void ChekingDashOrUnderscoreInEnd_ValidUsernameWithDashOrUnderscore_ReturnsTrue()
        {
            string validUsername = "hello_";
            UserName user = new UserName(validUsername);

            bool result = user.chekingDashOrUnderscoreInEnd(validUsername);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void ChekingDashOrUnderscoreInEnd_InvalidUsernameWithoutDashOrUnderscore_ReturnsFalse()
        {
            string invalidUsername = "happyyyy";
            UserName user = new UserName(invalidUsername);

            bool result = user.chekingDashOrUnderscoreInEnd(invalidUsername);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void UsernameProblemsHandler_ValidUsername_NoErrorMessage()
        {
            string validUsername = "sahar_one123";
            userName user = new userName(validUsername);

            user.usernameProblemsHandler();

            Assert.AreEqual(string.Empty, user.userNameErrorMessage);
        }

        [Test]
        public void UsernameProblemsHandler_InvalidUsername_ReturnsErrorMessage()
        {
            string invalidUsername = "-nazanin_";
            UserName user = new UserName(invalidUsername);

            user.usernameProblemsHandler();

            Assert.AreEqual("username shouldn't start with dash or underscore!", user.userNameErrorMessage);
        }
    }

    public class FullNameTest
    {
        [Test]
        public void ChekingLetters_ValidFullNameWithOnlyLetters_ReturnsTrue()
        {
            string validFullName = "Pooria Abbasi";
            FullName name = new FullName(validFullName);

            bool result = name.chekingLetters(validFullName);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void ChekingLetters_InvalidFullNameWithNonLetterCharacters_ReturnsFalse()
        {
            string invalidFullName = "Mahdi123 ghaemi";
            fullName name = new fullName(invalidFullName);

            bool result = name.chekingLetters(invalidFullName);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void FullNAmeValidator_ValidFullNameWithOnlyLetters_ReturnsTrue()
        {
            string validFullName = "zahra";
            fullName name = new fullName(validFullName);

            bool result = name.fullNAmeValidator(validFullName);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void FullNAmeValidator_InvalidFullNameWithNonLetterCharacters_ReturnsFalse()
        {
            string invalidFullName = "mani123 Ddd";
            fullName name = new fullName(invalidFullName);

            bool result = name.fullNAmeValidator(invalidFullName);

            Assert.AreEqual(false, result);
        }
    }

    public class PasswordTest
    {
        [Test]
        public void checkingUpperCaseLettersTest_validPasswordWithOnlyOneUpperCase_ReturnsTrue()
        {
            string validPassword = "12kdj7Ikns";
            password pwd = new password(validPassword);

            bool result = pwd.checkingUpperCaseLetters(validPassword);
            Assert.AreEqual(true, result);

        }

        [Test]
        public void checkingUpperCaseLettersTest_invalidPasswordWithoutAnyUpperCase_ReturnsFalse()
        {
            string invalidPassword = "f12hello";
            password pwd = new password(invalidPassword);

            bool result = pwd.checkingUpperCaseLetters(invalidPassword);
            Assert.AreEqual(false, result);

        }

        [Test]
        public void checkingLowerCaseLettersTest_validPasswordWithOnlyOneLowerCase_ReturnsTrue()
        {
            string validPassword = "SARA000RYHn";
            password pwd = new password(validPassword);

            bool result = pwd.checkingLowerCaseLetters(validPassword);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void checkingLowerCaseLettersTest_invalidPasswordWithoutAnyLowerCase_ReturnsFalse()
        {
            string invalidPassword = "AE1234561EQTV";
            password pwd = new password(invalidPassword);

            bool result = pwd.checkingLowerCaseLetters(invalidPassword);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void chekingLettersTest_validPasswordWithBothLowerCaseAndUpperCase_ReturnsTrue()
        {
            string validPassword = "j12SaRa";
            password pwd = new password(validPassword);

            bool result = pwd.chekingLetters(validPassword);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void chekingDigitsTest_validPasswordWithOnlyOneDigit_ReturnsTrue()
        {
            string validPassword = "1TestDigit";
            password pwd = new password(validPassword);

            bool result = pwd.chekingDigits(validPassword);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void chekingDigitsTest_invalidPasswordWithOnlyOneDigit_ReturnsFalse()
        {
            string invalidPassword = "IAmComputerStudent";
            password pwd = new password(invalidPassword);

            bool result = pwd.chekingDigits(invalidPassword);
            Assert.AreEqual(false, result);

        }

        [Test]
        public void chekingSpecialCharactersTest_validPasswordWithOnlyOneSPecialCharacter_ReturnsTrue()
        {
            string validPassword = "salaM0#";
            password pwd = new password(validPassword);

            bool result = pwd.chekingDigits(validPassword);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void chekingSpecialCharactersTest_invalidPasswordWithoutAnySpecialCharacter_ReturnsFalse()
        {
            string invalidPassword = "AComputerStudent";
            password pwd = new password(invalidPassword);

            bool result = pwd.chekingDigits(invalidPassword);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void chekingLengthTest_validPassswordWithEightCharacters_ReturnsTrue()
        {
            string validPassword = "SaraMnli";
            password pwd = new password(validPassword);

            bool result = pwd.chekingDigits(validPassword);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void chekingLengthTest_invalidPassswordWithMoreThanEightCharacters_ReturnsFalse()
        {
            string invalidPassword = "SaraManeli22@";
            password pwd = new password(invalidPassword);

            bool result = pwd.chekingDigits(invalidPassword);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void chekingLengthTest_validPassswordWithLessThanEightCharacters_ReturnsFalse()
        {
            string invalidPassword = "Sara1@";
            password pwd = new password(invalidPassword);

            bool result = pwd.chekingDigits(invalidPassword);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void passwordProblemsHandlerTest_ValidPassword_NoErrorMessage()
        {
            string validPassword = "Hi1402@m";
            password pwd = new password(validPassword);

            pwd.passwordProblemsHandler();

            Assert.AreEqual(string.Empty, pwd.passwordErrorMessage);
        }

        [Test]
        public void PasswordProblemsHandlerTest_InvalidPassword_ReturnsErrorMessage()
        {
            string invalidPassword = "";
            password pwd = new password(invalidPassword);

            pwd.passwordProblemsHandler();

            Assert.AreEqual("password must have digits!", pwd.passwordErrorMessage);
        }

        [Test]
        public void passwordValidationTest_CheckValidPasswordWithAllConditions_ReturnsTrue()
        {
            string validPassword = "Hi1#Site";
            password pwd = new password(validPassword);

            bool result = pwd.chekingDigits(validPassword);
            Assert.AreEqual(true, result);
        }
    }


    public class mobilePhoneTest
    {
        [Test]
        public void chekingDigitsTest_validMobilePhoneWithDigits_ReturnsTrue()
        {
            string validMobilePhone = "09123111111";
            mobilePhone phoneNum = new mobilePhone(validMobilePhone);

            bool result = phoneNum.chekingDigits(validMobilePhone);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void chekingDigitsTest_invalidMobilePhoneWithOneNonDigitCharacter_ReturnsFalse()
        {
            string invalidMobilePhone = "0912a111111";
            mobilePhone phoneNum = new mobilePhone(invalidMobilePhone);

            bool result = phoneNum.chekingDigits(invalidMobilePhone);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void chekingStartsWithZeroAndNineTest_validMobilePhoneStartingWithZeroAndNine_ReturnsTrue()
        {
            string validMobilePhone = "09000000000";
            mobilePhone phoneNum = new mobilePhone(validMobilePhone);

            bool result = phoneNum.chekingDigits(validMobilePhone);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void chekingStartsWithZeroAndNineTest_invalidMobilePhoneStartingWithZereWithoutNine_ReturnsFalse()
        {
            string invalidMobilePhone = "00123456789";
            mobilePhone phoneNum = new mobilePhone(invalidMobilePhone);

            bool result = phoneNum.chekingDigits(invalidMobilePhone);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void chekingStartsWithZeroAndNineTest_validMobilePhoneWithElevenDigits_ReturnsTrue()
        {
            string validMobilePhone = "09123456789";
            mobilePhone phoneNum = new mobilePhone(validMobilePhone);

            bool result = phoneNum.chekingDigits(validMobilePhone);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void chekingLengthEqualsToElevenTest_invalidMobilePhoneWithMoreThanElevenDigits_ReturnsFalse()
        {
            string invalidMobilePhone = "0912345678910";
            mobilePhone phoneNum = new mobilePhone(invalidMobilePhone);

            bool result = phoneNum.chekingDigits(invalidMobilePhone);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void chekingLengthEqualsToElevenTest_invalidMobilePhoneWithLessThanElevenDigits_ReturnsFalse()
        {
            string invalidMobilePhone = "091234567";
            mobilePhone phoneNum = new mobilePhone(invalidMobilePhone);

            bool result = phoneNum.chekingDigits(invalidMobilePhone);
            Assert.AreEqual(false, result);
        }
        [Test]
        public void mobilePhoneProblemsHandlerTest_ValidMobilePhone_NoErrorMessage()
        {
            string validMobilePhone = "09123456789";
            mobilePhone phoneNum = new mobilePhone(validMobilePhone);

            phoneNum.mobilePhoneProblemsHandler();

            Assert.AreEqual(string.Empty, phoneNum.moileErrorMessage);
        }

        [Test]
         public void mobilePhoneProblemsHandlerTest_InvalidMobilePhone_ReturnsErrorMessage()
         {
             string invalidMobilePhone = "09s23456789";
             MobilePhone phoneNum = new MobilePhone(invalidMobilePhone);
        
             phoneNum.mobilePhoneProblemsHandler();
        
             Assert.AreEqual("phone number must contain numbers!", phoneNum.moileErrorMessage);
         }

        [Test]
        public void mobilePhoneValidatorTest_CheckValidMobilePhoneWithAllConditions_ReturnsTrue()
        {
            string validMobilePhone = "09109283765";
            MobilePhone phoneNum = new MobilePhone(validMobilePhone);

            bool result = phoneNum.chekingDigits(validMobilePhone);
            Assert.AreEqual(true, result);
        }
    }
}