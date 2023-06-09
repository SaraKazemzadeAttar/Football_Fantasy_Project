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

            //log in API:
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/login",presentationLayer.login.loginApi);

           
            // end log in
            
            // calling List Of players API
            presentationLayer.signUp.signUpAPI(new user(1,"maneli1234","maneligmail.com","maforoutan"
            ,"1203R@fd","096790882"));
            
            
            
            app.Run("http://localhost:3001");
        }
            //end of calling list of players
            

            //app.MapPost("/signUp-User", presentationLayer.signUp.suignUpAPI);
            //app.Run();
        }
}
    // var builder = WebApplication.CreateBuilder(args);
    // var app = builder.Build();

    // app.MapPost("/signUp-User", presentationLayer.signUp.suignUpAPI);
    // app.Run();
    