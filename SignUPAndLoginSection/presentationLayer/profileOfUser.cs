      using SignUPAndLoginSection.DataAccessLayer;

 namespace SignUPAndLoginSection.presentationLayer;

 public class profileOfUser
 {
     public static User showUserinfo(User u )
     {
         using (var db = new DataBase())
         {
             foreach (var user in db.userTable)
             {
                 if (user.userId.Equals(u.userId) )
                     return new presentationLayer.User
                     {
                         fullName = user.fullName, score = user.score,userName=user.userName,
                         mobilePhone=user.mobilePhone,email=user.email,
                     } ;
             }
         }

         return null;
     }

     public static IResult showUserProfile(HttpContext inputToken)
     {
         var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
         var user = UsersData.FindUserByTheirToken(token);
         presentationLayer.User userInfo=showUserinfo(user);
         return Results.Ok(userInfo );
     }
 }