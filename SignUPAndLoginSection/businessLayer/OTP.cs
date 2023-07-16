 using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;
 using System;
using System.Net;
using System.Net.Mail;
 
 namespace  SignUPAndLoginSection.businessLayer;

public class OTP
{
    public static string GenerateRandomCode()
    {
        Random random = new Random();
        int randomNumber = random.Next(1000, 10000);
        string strnum = randomNumber.ToString();
        return strnum;
    }
    public static string send_code(presentationLayer.User u)
    {
        
        
        MailMessage mail = new MailMessage();
        SmtpClient smtp = new SmtpClient("smtp.gmail.com");

        mail.From = new MailAddress("shahedap.footballfantasy@gmail.com");
        mail.Subject = "Fotball Fantasy";
        mail.To.Add(u.email);
        mail.Body = GenerateRandomCode();

        smtp.Port = 587;
        smtp.Credentials = new System.Net.NetworkCredential("shahedap.footballfantasy@gmail.com", "vfecuirpkbwojjkj");
        smtp.EnableSsl = true;
       
        smtp.Send(mail);
        return mail.Body;
    }

    public static IResult ValidatinOTPCode(presentationLayer.User u)
    {
        int counter = 0;
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                if (user.email.Equals(u.email) && user.OTPCode.Equals(u.OTPCode))
                    counter++;

                if (counter == 1)

                {
                    user.isvalid = true;
                    db.SaveChanges();
                    return Results.Ok(new
                        {
                            message = "signUp was successful"
                        }
                    );
                }
            }
        }
        return Results.BadRequest(new
            {
                message = "signUp was not successful"
            }
        ); 
    }
}


