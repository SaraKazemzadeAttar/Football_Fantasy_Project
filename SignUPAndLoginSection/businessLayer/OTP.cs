namespace SignUPAndLoginSection;
using System;
using System.Net;
using System.Net.Mail;

public class OTP
{
    public void send_code()
    {
        Random random = new Random();
        int randomNumber = random.Next(1000, 10000);
        string strnum = randomNumber.ToString();

        MailMessage mail = new MailMessage();
        SmtpClient smtp = new SmtpClient("smtp.gmail.com");

        mail.From = new MailAddress("shahedap.footballfantasy@gmail.com");
        mail.Subject = "Fotball Fantasy";
        mail.To.Add("maneli0foroutan@gmail.com");
        mail.Body = strnum;

        smtp.Port = 587;
        smtp.Credentials =
            new System.Net.NetworkCredential("shahedap.footballfantasy@gmail.com", "vfecuirpkbwojjkj");
        smtp.EnableSsl = true;

        smtp.Send(mail);
    }
}