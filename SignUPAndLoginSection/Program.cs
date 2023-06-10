
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
            otp.send_code();

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            // presentationLayer.signUp.signUpAPI(new user(1,"maneli1234","maneligmail.com","maforoutan"
            //     ,"1203R@fd","096790882"));
            // //log in API:

            app.MapGet("/login",presentationLayer.login.loginApi);

        }


        //app.MapPost("/signUp-User", presentationLayer.signUp.suignUpAPI);
            //app.Run();
        }
}
    // var builder = WebApplication.CreateBuilder(args);
    // var app = builder.Build();

    // app.MapPost("/signUp-User", presentationLayer.signUp.suignUpAPI);

    