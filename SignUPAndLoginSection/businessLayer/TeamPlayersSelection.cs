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
        CreationTeam.changingRoleOfMainPlayer(targetUserId,selectedPlayerId);
        CreationTeam.changingRoleOfSubstitutePlayer(targetUserId,selectedPlayerId);
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



    public static bool hasUserEnoughMoney(presentationLayer.User user, Player selectedPlayer)
    {
        if (user.cash <selectedPlayer.now_cost)
        {
            return false;
        }
    
        return true;
    }
    
    public static bool AreSelectedPlayerInCorrectArrange( int targetUserId, Player selectedPlayer)
    {
        var intendedPost =selectedPlayer.element_type;
        switch (intendedPost)
        {
            case Post.Goalkeeper:
                return (FootballPlayersData.selectedPlayersPostList(targetUserId, Post.Goalkeeper).Count < 2);
            case Post.Defender:
                return (FootballPlayersData.selectedPlayersPostList(targetUserId, Post.Defender).Count < 5);
            case Post.Midfielder:
                return FootballPlayersData.selectedPlayersPostList(targetUserId, Post.Midfielder).Count < 5;
            case Post.Forward:
                return FootballPlayersData.selectedPlayersPostList(targetUserId, Post.Forward).Count < 3;
            default:
                return false;
        }
    }
    
    public static bool AreUnderFourPlayersFromOneTeam(int targetUserId,Player selectedPlayer)
    {
        var playerTeam = selectedPlayer.team;
        
        if (FootballPlayersData.selectedPlayersTeamList(targetUserId ,playerTeam).Count > 4)
        {
            return false;
        }
    
        return true;
    }

    public static List<string> ShowListOfMyTeam(string token)
    {
        var user = UsersData.FindUserByTheirToken(token);
        return CreationTeam.showListOfMyTeam(user.userId);
    }

    
}