using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;

namespace SignUPAndLoginSection.presentationLayer;

public class TeamPlayerSelection
{
    public static string errorMessage = "";

    public static bool isSelectionSuccessful(string token, int selectedPlayerId)
    {
        Player convertedPl = FootballPlayersData.findPLayerByTheirId(selectedPlayerId);
        var user = UsersData.FindUserByTheirToken(token);
        bool moneyCondition = businessLayer.Cash.hasUserEnoughMoney(user, convertedPl);
        bool arrangeCondition = TeamPlayersSelection.AreSelectedPlayerInCorrectArrange(user.userId, convertedPl);
        bool teamCondition = TeamPlayersSelection.AreUnderFourPlayersFromOneTeam(user.userId, convertedPl);
        bool isPlayerUniqueInTeam = ListOfMyTeamPlayers.isPlayerUniqueInMyTeam(user.userId, selectedPlayerId);

        if (isPlayerUniqueInTeam && moneyCondition && arrangeCondition && teamCondition)
        {
            businessLayer.Cash.buySelectedPlayer(user, selectedPlayerId);
            return true;
        }
        else if (!moneyCondition)
        {
            errorMessage = "You have not enough money to buy this player!";
        }
        else if (!arrangeCondition)
        {
            errorMessage = "This player is not in correct arrange in your team!";
        }
        else if (!teamCondition)
        {
            errorMessage = "You have selected three players from this team before!";
        }
        else if (!isPlayerUniqueInTeam)
        {
            errorMessage = "You have selected this player before!";
        }

        return false;
    }

    public static IResult selectionPlayerAPI(HttpContext inputToken, string playerIdStr)
    {
        int playerId = Convert.ToInt32(playerIdStr);
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        if (isSelectionSuccessful(token, playerId))
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
                message = "Selection was not successful! " + errorMessage
            });
        }
    }

    public static IResult setTheMainPlayer(HttpContext inputToken,string playerIdStr)
    {
        int playerId = Convert.ToInt32(playerIdStr);
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        if (TeamPlayersSelection.isSettingMainPlayerSuccessful(token, playerId))
        {
            return Results.Ok(new
                {
                    message = "Player is set as main player in your team!"
                }
            );
        }
        else
        {
            return Results.BadRequest(new
            {
                message = "This player is not in your team! "
            });
        }
    }

    public static IResult setTheSubstitutePlayer(HttpContext inputToken, string playerIdStr)
    {
        int playerId = Convert.ToInt32(playerIdStr);
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        if (TeamPlayersSelection.isSettingSubstitutePlayerSuccessful(token, playerId))
        {
            return Results.Ok(new
                {
                    message = "Player is set as substitute player in your team!"
                }
            );
        }
        else
        {
            return Results.BadRequest(new
            {
                message = "This player is not in your team! "
            });
        }
    }
    public static IResult omittingPlayerAPI(HttpContext inputToken, string playerIdStr)
    {
        int playerId = Convert.ToInt32(playerIdStr);
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        if (TeamPlayersSelection.isOmittingPlayerSuccessful(token, playerId))
        {
            return Results.Ok(new
                {
                    message = "Omitting was successful!"
                }
            );
        }
        else
        {
            return Results.BadRequest(new
            {
                message = "This player is not in your team! "
            });
        }
    }

    public static IResult changeRoleOfPlayerAPI(HttpContext inputToken, string firstPlayerIdStr , string secondPlayerIdstr)
    {
        int firstPlayerId = Convert.ToInt32(firstPlayerIdStr);
        int secondPlayerId = Convert.ToInt32(secondPlayerIdstr);
        var token = inputToken.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.ToString();
        if (TeamPlayersSelection.isChangingRoleSuccessful(token, firstPlayerId,secondPlayerId))
        {
            return Results.Ok(new
                {
                    message = "Changing role was successful!"
                }
            );
        }
        else
        {
            return Results.BadRequest(new
            {
                message = "This players are not in your team! "
            });
        }
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

