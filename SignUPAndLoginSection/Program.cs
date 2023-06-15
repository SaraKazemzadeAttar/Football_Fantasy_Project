
using System;
using System.Net;
using System.Net.Mail;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection
{
    public class program
    {
        public static void Main(string[] args)
        {
            DataAccessLayer.FootballPlayersData.insertPlayersInDataBase();

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.MapPost("/login", presentationLayer.login.loginApi);
            app.MapPost("/signUp", presentationLayer.SignUp.signUPAPI);
            app.MapPost("/otp", businessLayer.OTP.ValidatinOTPCode);
           


            app.Run("http://localhost:3001");
        }
    }
}