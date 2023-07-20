using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class Cash
{
    public static IResult displayUserCash(HttpContext inputToken)
    { 
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        var user = UsersData.FindUserByTheirToken(token);
        return Results.Json(user.userId);
    }
}