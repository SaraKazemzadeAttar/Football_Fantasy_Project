using System.Diagnostics;
using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class TeamPlayerSelection
{
    public static IResult SelectionPlayerAPI(string token, string playerName)
    {
        Player player = FootballPlayersData.findPlayerByTheirName(playerName);
        UsersTeamPlayers selectedPlayer = new UsersTeamPlayers(player);
        string email_username =TokenAccess.getEmailOrUsernameFromToken(token);
            if(businessLayer.TeamPlayersSelection.isSelectionSuccessful(token, selectedPlayer))
        {
            return Results.Ok(new
                {
                    message = "Selection was successful!"
                }
            );
        }
        else
        {
            return Results.BadRequest(new
                {
                    message = "Selection was not successful!"
                }
            );
        }
    }
}