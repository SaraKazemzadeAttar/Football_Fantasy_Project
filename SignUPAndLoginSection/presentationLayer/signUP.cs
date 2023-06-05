namespace SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
public class signUp
{
    
    public static void signUpAPI(user u)
    {
        // if validUser == true -> check : is it new or repeated?
        //                                     if new -> save the user
        //                                     if repeated:
        //                                                 email repeated -> error message
        //                                                 mobile repeated -> error message
        //                                                 username repeated -> error message
        //  if validUser == false -> special error message must be returned 
        userValidator user = new userValidator(u);
        if(user.userValidating())
            Console.WriteLine("ok");
        else 
            Console.WriteLine("not ok");
    }
    
}