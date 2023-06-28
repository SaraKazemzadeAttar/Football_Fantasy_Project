using System;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection.businessLayer;

public class TeamPlayersSelection
{
    public void changeRoleOfPlayer(UsersTeamPlayers selectedPlayer)
    {
        UsersTeamPlayers.changingRoleOfPlayer(selectedPlayer);
    }

    public void omitPlayer(UsersTeamPlayers selectedPlayer, string token)  // I doubt so much... !!!???
    {
        presentationLayer.User user = UsersData.FindUserByTheirToken(token);
        int targetId = user.userId;
        UsersTeamPlayers.RemovePlayer(selectedPlayer, targetId);
    }

    public static bool AreSelectedPlayerInCorrectArrange(UsersTeamPlayers selectedPlayer)
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

    public static bool hasUserEnoughMoney(string token, UsersTeamPlayers selctedPlayer)
    {
        var user = UsersData.FindUserByTheirToken(token);
        if (user.cash < selctedPlayer.nowCost)
        {
            UsersTeamPlayers.selectionPlayerErrorMessage = "You have not enough money to buy this player!";
            return false;
        }

        return true;
    }

    public static bool AreUnderFourPlayersFromOneTeam(UsersTeamPlayers selectedPlayer)
    {
        if (UsersTeamPlayers.numberOfPlayersFromThisTeam(selectedPlayer) > 4)
        {
            UsersTeamPlayers.selectionPlayerErrorMessage = "You have selected three players from this team before!";
            return false;
        }

        return true;
    }

    public static void playerSelection (UsersTeamPlayers selectedPlayer)
    {
        UsersTeamPlayers.insertSelectedPlayerInUserTeam(selectedPlayer);
    }
    
    public static bool isSelectionSuccessful(string token, UsersTeamPlayers selectedPlayer)
    {
        bool MoneyCondition = hasUserEnoughMoney(token, selectedPlayer);
        bool ArrangeCondition = AreSelectedPlayerInCorrectArrange(selectedPlayer);
        bool TeamCondition = AreUnderFourPlayersFromOneTeam(selectedPlayer);

        if (MoneyCondition && ArrangeCondition && TeamCondition)
        {
            selectedPlayer.hasPlayerSelectionConditions = true;
            playerSelection(selectedPlayer);
            return true;
        }
        else
        {
            selectedPlayer.hasPlayerSelectionConditions = false;
            return false;
        }
    }
}