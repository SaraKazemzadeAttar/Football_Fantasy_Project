      using SignUPAndLoginSection.DataAccessLayer;

 namespace SignUPAndLoginSection.presentationLayer;

 public class profileOfUser
 {
     public static string showUserName(User userprofile )
     {
         using (var db = new DataBase())
         {
             foreach (var user in db.userTable)
             {
                 if (userprofile.userId == user.userId)
                     return user.fullName ;
             }
         }

         return null;
     }

     public static string showUserMobilePhone(User userprofile)
     {
         using (var db = new DataBase())
         {
             foreach (var user in db.userTable)
             {
                 if (userprofile.userId == user.userId)
                     return user.mobilePhone;
             }
         }
         return null;
     }

     public static string showUserEmail(User userprofile)
     {
         using (var db = new DataBase())
         {
             foreach (var user in db.userTable)
             {
                 if (userprofile.userId == user.userId)
                     return user.email;
             }
         }
         return null;
     }
     public static string showUserUserName(User userprofile)
     {
         using (var db = new DataBase())
         {
             foreach (var user in db.userTable)
             {
                 if (userprofile.userId == user.userId)
                     return user.userName;
             }
         }
         return null;
     }
    
     public static string userProfile(User userprofile)
     {
         return showUserName(userprofile)+showUserMobilePhone(userprofile)+showUserEmail(userprofile)+
                showUserUserName(userprofile);
         
     }

     public static IResult showUserProfile(HttpContext inputToken)
     {
         var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
         var user = UsersData.FindUserByTheirToken(token);
         string userData=userProfile(user);
         return Results.Ok(userData);
     }
 }