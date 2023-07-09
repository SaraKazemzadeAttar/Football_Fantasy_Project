using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class TeamPlayerSelection
{
    public static IResult selectionPlayerAPI(string token, int playerId)
    {

        UsersTeamPlayers selectedPlayer = new UsersTeamPlayers();
        if (businessLayer.TeamPlayersSelection.isSelectionSuccessful(token, playerId))
        {
            return Results.Ok(new
                {
                    message = "selection was successful!"
                }
            );
        }
        else
        {
            return Results.BadRequest(new
            {
                message = "selection was not successful!"
            });
        }
    }

    public static IResult omittingPlayerAPI(string token, int playerId)
    {
        UsersTeamPlayers selectedPlayer = new UsersTeamPlayers();
        businessLayer.TeamPlayersSelection.omitPlayer(token, playerId);
        return Results.Ok(new
            {
                message = "selection was successful!"
            }
        );
    }
}

