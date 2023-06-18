using System;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;
namespace SignUPAndLoginSection.businessLayer;

public class TeamPlayersSelection
{

    public void changeRoleOfPlayers()
    {
        
    }

    public void omitPlayers()
    {


    }

    // public bool AreSelectedPlayersInCorrectArrange(Player selectedPlayer)
    // {
    //     
    // }

    public bool hasUserEnoughMoney(string token ,Player selectedPlayer)
    {
        var email_username = TokenAccess.getEmailOrUsernameFromToken(token);
        var user=UsersData.FindUserByTheirEmail_Username(email_username);
        if (user.cash < selectedPlayer.now_cost)
        {
            UsersTeamPlayers.selectionPlayerErrorMessage = "You have not enough money to buy the player";
            return false;
        }
        return true;
    }
    
    public void playerSelection(string token , int id) // Q :is this id the field which I want?
    {
        Player selectedPlayer = FootballPlayersData.findPLayerByTheirId(id);
        hasUserEnoughMoney(token, selectedPlayer);
        // AreSelectedPlayersInCorrectArrange( selectedPlayer);
        // AreLessThanThreeSelectedPlayersFromATeam( selectedPlayer);// bad name

    }
        
}