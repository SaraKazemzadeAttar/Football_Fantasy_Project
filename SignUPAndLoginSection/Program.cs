using System;
using System.Net;
using System.Net.Mail;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection
{
    public class program
    {
        public static void Main(string[] args)
        {
            OTP otp = new OTP();
            otp.send_code(Model.User user);

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.MapPost("/login", presentationLayer.login.loginApi);
            app.MapPost("/signUp", presentationLayer.SignUp.signUPAPI);
            app.MapPost("/signUp", businessLayer.OTP.ValidatinOTPCode);
           


            app.Run("http://localhost:3001");
        }
    }
}