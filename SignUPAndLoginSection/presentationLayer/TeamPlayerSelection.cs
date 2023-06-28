using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class TeamPlayerSelection
{
    public static IResult SelectionPlayerAPI(string token, string playerName)
    { 
        var player = FootballPlayersData.findPlayerByTheirName(playerName);
       public UsersTeamPlayers selectedPlayer = new UsersTeamPlayers(new);
    // businessLayer.TeamPlayersSelection.playerSelection(token, selectedPlayer);
}