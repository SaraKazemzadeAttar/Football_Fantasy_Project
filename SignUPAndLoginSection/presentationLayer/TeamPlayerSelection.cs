using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;


namespace SignUPAndLoginSection.presentationLayer;

public class TeamPlayerSelection
{
    public static IResult selectionPlayerAPI(HttpContext inputToken, int playerId)
    {
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authentication").Value.ToString();
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

    public static IResult omittingPlayerAPI(HttpContext inputToken, int playerId)
    {
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authentication").Value.ToString();
        UsersTeamPlayers selectedPlayer = new UsersTeamPlayers();
        businessLayer.TeamPlayersSelection.omitPlayer(token, playerId);
        return Results.Ok(new
            {
                message = "omitting was successful!"
            }
        );
    }

    public static IResult changeRoleOfPlayerAPI(HttpContext inputToken, int playerId)
    {
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authentication").Value.ToString();
        UsersTeamPlayers selectedPlayer = new UsersTeamPlayers();
        businessLayer.TeamPlayersSelection.changeRoleOfPlayer(token, playerId);
        return Results.Ok(new
            {
                message = "changing role was successful!"
            }
        );
    }
    
    
}

