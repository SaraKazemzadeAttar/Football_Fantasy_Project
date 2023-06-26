using System;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection.businessLayer;

public class TeamPlayersSelection
{
    public void changeRoleOfPlayer(UsersTeamPlayers up)
    {
        UsersTeamPlayers.changingRoleOfPlayer(up);
    }

    public void omitPlayers(UsersTeamPlayers up, User u)
    {
        
        
    }

    public bool AreSelectedPlayerInCorrectArrange(UsersTeamPlayers selectedPlayer)
    {
        var intendedPost = selectedPlayer.post;
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

    public bool hasUserEnoughMoney(string token, UsersTeamPlayers selctedPlayer)
    {
        var email_username = TokenAccess.getEmailOrUsernameFromToken(token);
        var user = UsersData.FindUserByTheirEmail_Username(email_username);
        if (user.cash < selctedPlayer.nowCost)
        {
            UsersTeamPlayers.selectionPlayerErrorMessage = "You have not enough money to buy this player!";
            return false;
        }

        return true;
    }

    public bool AreUnderFourPlayersFromOneTeam(UsersTeamPlayers selectedPlayer)
    {
        if (UsersTeamPlayers.numberOfPlayersFromThisTeam(selectedPlayer) > 4)
        {
            UsersTeamPlayers.selectionPlayerErrorMessage = "You have selected three players from this team before!";
            return false;
        }

        return true;
    }

    public void playerSelection(string token, UsersTeamPlayers selectedPlayer) // Q :should be IResult and in presentaion?
    {
        bool MoneyCondition = hasUserEnoughMoney(token, selectedPlayer);
        bool ArrangeCondition = AreSelectedPlayerInCorrectArrange(selectedPlayer);
        bool TeamCondition = AreUnderFourPlayersFromOneTeam(selectedPlayer);

        if (MoneyCondition && ArrangeCondition && TeamCondition)
        {
            UsersTeamPlayers.insertSelectedPlayerInUserTeam(selectedPlayer);
        }
    }
}