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
        if (businessLayer.TeamPlayersSelection.isSelectionSuccessful(token, selectedPlayer))
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

    public static IResult omitPlayerAPI(string token, string playerName) 
        // can an IResult Method has no badRequest or do we need IResult method at all?
    {
        Player player = FootballPlayersData.findPlayerByTheirName(playerName);
        UsersTeamPlayers selectedPlayer = new UsersTeamPlayers(player);
        TeamPlayersSelection.omitPlayer(token, selectedPlayer);
        return Results.Ok(new
            {
                message = " Player is omitted successfully !"
            }
        );
    }

    public static IResult changeRoleOfPlayerAPI(string token, string playerName) // Didnt undrestand completely! :/
    {
        Player player = FootballPlayersData.findPlayerByTheirName(playerName);
        UsersTeamPlayers selectedPlayer = new UsersTeamPlayers(player);
        businessLayer.TeamPlayersSelection.changeRoleOfPlayer(token, selectedPlayer);
        return Results.Ok(new
            {
                message = " Role of player is changed successfully !"
            }
        );
    }
}
