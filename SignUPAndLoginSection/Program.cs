using System;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection
{
    public class program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            presentationLayer.signUp.suignUpAPI(new user(1,"maneli1234","maneligmail.com","maforoutan"
                ,"1203R@fd","096790882"));
            app.MapPost("/signUp-User", presentationLayer.signUp.suignUpAPI);
            app.Run();
        }
    }
    // var builder = WebApplication.CreateBuilder(args);
    // var app = builder.Build();

    // app.MapPost("/signUp-User", presentationLayer.signUp.suignUpAPI);
    // app.Run();

}