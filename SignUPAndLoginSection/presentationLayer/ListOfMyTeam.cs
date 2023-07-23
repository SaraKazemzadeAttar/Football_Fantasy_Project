using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class ListOfMyTeam
{
    public static List<string> ListOfMainPlayers(HttpContext inputToken )
    {
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        var user = UsersData.FindUserByTheirToken(token);
        List<UsersTeamPlayers> mainPlayersList= ListOfMyTeamPlayers.myMainPlayersList(user.userId);
        List<string> listOfMainPlayers = new List<string>();
        string info = "";
        foreach (var player in mainPlayersList)
        {
            info= ListOfMyTeamPlayers.showInfoOfPlayer(player.playerId);
            listOfMainPlayers.Add(info);
        }

        return listOfMainPlayers;
    }
    
    public static List<string> ListOfSubstitutePlayers(HttpContext inputToken )
    {
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        var user = UsersData.FindUserByTheirToken(token);
        List<UsersTeamPlayers> substitutePlayersList= ListOfMyTeamPlayers.mySubstitutePlayersList(user.userId);
        List<string> listOfSubstitutePlayers = new List<string>();
        string info = "";
        foreach (var player in substitutePlayersList)
        {
            info= ListOfMyTeamPlayers.showInfoOfPlayer(player.playerId);
            listOfSubstitutePlayers.Add(info);
        }

        return listOfSubstitutePlayers;
    }
}