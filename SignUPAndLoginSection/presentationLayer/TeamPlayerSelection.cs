using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace SignUPAndLoginSection.presentationLayer;

public class TeamPlayerSelection
{
    public static string errorMessage = "";
    public static bool isSelectionSuccessful(string token, int selectedPlayerId)
    {
        Player convertedPl = FootballPlayersData.findPLayerByTheirId(selectedPlayerId);
        var user = UsersData.FindUserByTheirToken(token);
        bool moneyCondition = TeamPlayersSelection.hasUserEnoughMoney(user, convertedPl );
        bool arrangeCondition = TeamPlayersSelection.AreSelectedPlayerInCorrectArrange( user.userId,convertedPl);
        bool teamCondition = TeamPlayersSelection.AreUnderFourPlayersFromOneTeam(user.userId,convertedPl);
        bool isPlayerUniqueInTeam =CreationTeam.isPlayerUniqueInMyTeam(user.userId, selectedPlayerId);
    
        if (isPlayerUniqueInTeam && moneyCondition && arrangeCondition && teamCondition)
        {
            TeamPlayersSelection.buySelectedPlayer(user, selectedPlayerId);
            return true;
        }
        else if(!moneyCondition)
        {
            errorMessage="You have not enough money to buy this player!";
            return false;
        }
        else if(!arrangeCondition)
        {
            errorMessage = "This player is not in correct arrange in your team!";
            return false;
        }
        else if (!teamCondition)
        {
            errorMessage = "You have selected three players from this team before!";
            return false;
        }
        else if (!isPlayerUniqueInTeam)
        {
            errorMessage = "You have selected this player before!";
        }

        return false;
    }
    public static IResult selectionPlayerAPI(HttpContext inputToken , string playerIdStr)
    {
        int playerId = Convert.ToInt32(playerIdStr);
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        if (isSelectionSuccessful( token, playerId))
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
                message = "selection was not successful! "+ errorMessage
            });
        }
    }

    public static IResult omittingPlayerAPI(HttpContext inputToken, string playerIdStr)
    {
        int playerId = Convert.ToInt32(playerIdStr);
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        UsersTeamPlayers selectedPlayer = new UsersTeamPlayers();
        businessLayer.TeamPlayersSelection.omitPlayer(token, playerId);
        return Results.Ok(new
            {
                message = "omitting was successful!"
            }
        );
    }

    public static IResult changeRoleOfPlayerAPI(HttpContext inputToken, string playerIdStr)
    {
        int playerId = Convert.ToInt32(playerIdStr);
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        UsersTeamPlayers selectedPlayer = new UsersTeamPlayers();
        businessLayer.TeamPlayersSelection.changeRoleOfPlayer(token, playerId);
        return Results.Ok(new
            {
                message = "changing role was successful!"
            }
        );
    }

    public static IResult showSelectedPlayersAPI(HttpContext inputToken)
    {
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        List<string> selectedPlayersList = TeamPlayersSelection.ShowListOfMyTeam(token);
        return Results.Ok(new
            {
                selectedPlayersList
            }
        );
    }
    
    
}

