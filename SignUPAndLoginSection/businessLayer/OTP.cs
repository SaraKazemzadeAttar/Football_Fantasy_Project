 using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace  SignUPAndLoginSection.businessLayer;


using System;
using System.Net;
using System.Net.Mail;

public class OTP
{
    public static string GenerateRandomCode()
    {
        Random random = new Random();
        int randomNumber = random.Next(1000, 10000);
        string strnum = randomNumber.ToString();
        return strnum;
    }
    public static void send_code(presentationLayer.User u)
    {
        MailMessage mail = new MailMessage();
        SmtpClient smtp = new SmtpClient("smtp.gmail.com");

        mail.From = new MailAddress("shahedap.footballfantasy@gmail.com");
        mail.Subject = "Fotball Fantasy";
        mail.To.Add(u.email);
        mail.Body = GenerateRandomCode();

        smtp.Port = 587;
        smtp.Credentials =
            new System.Net.NetworkCredential("shahedap.footballfantasy@gmail.com", "vfecuirpkbwojjkj");
        smtp.EnableSsl = true;

        smtp.Send(mail);
    }

    public static void  ValidatinOTPCode(presentationLayer.User u)
    {
        using (var db = new DataBase())
        {
            foreach (var email in db.userTable)
            {
                if (email.Equals(u.email) && GenerateRandomCode().Equals(u.OTPCode))
                    u.isvalid = true;

                else
                    u.isvalid = false;
            }

        }
        
    }
}


