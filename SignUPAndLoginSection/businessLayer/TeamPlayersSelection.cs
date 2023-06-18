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

    public bool AreSelectedPlayerInCorrectArrange(Player selectedPlayer)
    {
        var intendedPost = selectedPlayer.element_type;
        Player.Post intFormOfPost = (Player.Post)Convert.ToInt16(intendedPost);
        switch (intendedPost) 
        {
            case Player.Post.Goalkeeper:
                 return UsersTeamPlayers.hasTeamUnderTwoGoalKeepers();
            case Player.Post.Defender:
                   return UsersTeamPlayers.hasTeamUnderFiveDefenders();
                    case Player.Post.Midfielder:
                        return UsersTeamPlayers.hasTeamUnderFiveMidfielders();
                    case Player.Post.Forward:
                        return UsersTeamPlayers.hasTeamUnderThreeForwards();
                    default:
                        return false;
        }
    }

    public bool hasUserEnoughMoney(string token ,Player selectedPlayer)
    {
        var email_username = TokenAccess.getEmailOrUsernameFromToken(token);
        var user=UsersData.FindUserByTheirEmail_Username(email_username);
        if (user.cash < selectedPlayer.now_cost)
        {
            UsersTeamPlayers.selectionPlayerErrorMessage = "You have not enough money to buy the player!";
            return false;
        }
        return true;
    }

    public bool AreUnderThreePlayersFromOneTeam(Player selectedPlayer)
    {
        if (UsersTeamPlayers.numberOfPlayersFromThisTeam(selectedPlayer) >= 3)
        {
            UsersTeamPlayers.selectionPlayerErrorMessage = "You have selected two players from this team before!";
            return false;
        }

        return true;
    }
    public void playerSelection(string token , int id) // Q :is this id the field which I want? ----- should be IResult and in presentaion
    {
        Player selectedPlayer = FootballPlayersData.findPLayerByTheirId(id);
        bool MoneyCondition =hasUserEnoughMoney(token, selectedPlayer);
        bool ArrangeCondition =AreSelectedPlayerInCorrectArrange( selectedPlayer);
        bool TeamCondition=AreUnderThreePlayersFromOneTeam( selectedPlayer);

        if (MoneyCondition && ArrangeCondition && TeamCondition)
        {
            UsersTeamPlayers.insertSelectedPlayerInUserTeam(selectedPlayer);
        }

    }
        
}