using System;
using System.Net;
using System.Net.Mail;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.Model;
using SignUPAndLoginSection.presentationLayer;
using User = SignUPAndLoginSection.Model.User;

namespace SignUPAndLoginSection
{
    public class program
    {
        public static void Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.MapPost("/login", presentationLayer.login.loginApi);
            app.MapPost("/signUp", presentationLayer.SignUp.signUPAPI);
            app.MapPost("/otp", businessLayer.OTP.ValidatinOTPCode);
           


            app.Run("http://localhost:3001");
        }
    }
}