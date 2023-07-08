using System;
using ServiceStack;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection.businessLayer;

public class TeamPlayersSelection
{
    public static void changeRoleOfPlayer(string token ,int selectedPlayerId)
    {
        var user = UsersData.FindUserByTheirToken(token);
        int targetUserId = user.userId;
        CreationTeam.changingRoleOfPlayer(targetUserId,selectedPlayerId);
    }
    public static void buySelectedPlayer(presentationLayer.User user, int playerId)
    {
        CreationTeam.insertSelectedPlayerInUserTeam(user.userId,playerId);
        Player convertedPl = FootballPlayersData.findPLayerByTheirId(playerId);
        user.cash =- convertedPl.now_cost;
    }
    public static void omitPlayer(string token ,int playerId) 
    {
        var user = UsersData.FindUserByTheirToken(token);
        int targetUserId = user.userId;
        CreationTeam.RemovePlayer(targetUserId,playerId);
        returnMoneyToUser(user, playerId);
    }

    public static void returnMoneyToUser(presentationLayer.User user, int playerId)
    {
        Player convertedPl = FootballPlayersData.findPLayerByTheirId(playerId);
        user.cash =+ convertedPl.now_cost;
    }

    public static bool isSelectionSuccessful(string token, int selectedPlayerId)
    {
        Player convertedPl = FootballPlayersData.findPLayerByTheirId(selectedPlayerId);
        var user = UsersData.FindUserByTheirToken(token);
        bool MoneyCondition = hasUserEnoughMoney(user, convertedPl );
        bool ArrangeCondition = AreSelectedPlayerInCorrectArrange( user.userId,convertedPl);
        bool TeamCondition = AreUnderFourPlayersFromOneTeam(user.userId,convertedPl);
    
        if (MoneyCondition && ArrangeCondition && TeamCondition)
        {
            buySelectedPlayer(user, selectedPlayerId);
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool hasUserEnoughMoney(presentationLayer.User user, Player selectedPlayer)
    {
        if (user.cash <selectedPlayer.now_cost)
        {
            //UsersTeamPlayers.selectionPlayerErrorMessage = "You have not enough money to buy this player!";
            return false;
        }
    
        return true;
    }
    
    public static bool AreSelectedPlayerInCorrectArrange( int targetUserId, Player selectedPlayer)
    {
        var intendedPost =selectedPlayer.element_type;
        switch (intendedPost)
        {
            case Player.Post.Goalkeeper:
                return (FootballPlayersData.selectedPlayersPostList(targetUserId, Player.Post.Goalkeeper).Count < 2);
            case Player.Post.Defender:
                return (FootballPlayersData.selectedPlayersPostList(targetUserId, Player.Post.Defender).Count < 5);
            case Player.Post.Midfielder:
                return FootballPlayersData.selectedPlayersPostList(targetUserId, Player.Post.Midfielder).Count < 5;
            case Player.Post.Forward:
                return FootballPlayersData.selectedPlayersPostList(targetUserId, Player.Post.Forward).Count < 3;
            default:
                return false;
        }
    }
    
    public static bool AreUnderFourPlayersFromOneTeam(int targetUserId,Player selectedPlayer)
    {
        var playerTeam = selectedPlayer.team;
        
        if (FootballPlayersData.selectedPlayersTeamList(targetUserId ,playerTeam).Count > 4)
        {
            //UsersTeamPlayers.selectionPlayerErrorMessage = "You have selected three players from this team before!";
            return false;
        }
    
        return true;
    }
    

    
}