using System;
using System.Net.Mail;

class program
{
   //static void Main()
   //{
   //    string email = "example@example.com";
   //    string confirmationLink = "https://www.example.com/confirm";

   //    SendConfirmationEmail(email, confirmationLink);
   //}

    static void SendConfirmationEmail(string email, string confirmationLink)
    {
        MailMessage mail = new MailMessage();
        SmtpClient smtpClient = new SmtpClient("your_smtp_server");

        mail.From = new MailAddress("your_email_address");
        mail.To.Add(email);
        mail.Subject = "Email Confirmation";
        mail.Body = $"Please click the following link to confirm your email address: {confirmationLink}";

        try
        {
            smtpClient.Send(mail);
            Console.WriteLine("Confirmation email sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send confirmation email: {ex.Message}");
        }
    }
}