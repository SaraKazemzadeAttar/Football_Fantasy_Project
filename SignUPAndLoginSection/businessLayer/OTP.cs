using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.Model;

namespace SignUPAndLoginSection;
using System;
using System.Net;
using System.Net.Mail;

public class OTP
{
    public string GenerateRandomCode()
    {
        Random random = new Random();
        int randomNumber = random.Next(1000, 10000);
        string strnum = randomNumber.ToString();
        return strnum;
    }
    public void send_code(Model.User u)
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

    public void ValidatinOTPCode(Model.User u)
    {
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (u.OTPEmail.Equals(u.email) && GenerateRandomCode().Equals(u.OTPCode))
                    u.OTPCodeValidation = true;

                else
                    u.OTPCodeValidation = false;
            }

        }
        
    }
}