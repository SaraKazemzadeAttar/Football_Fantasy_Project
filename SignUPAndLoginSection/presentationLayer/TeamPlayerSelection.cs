using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class TeamPlayerSelection
{
    public static IResult SelectionPlayerAPI(string token, int playerId)
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
                 message= "selection was not successful!"
             });
         }

    }
}
