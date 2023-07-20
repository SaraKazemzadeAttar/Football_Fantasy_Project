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
    public static bool isOmittingPlayerSuccessful(string token ,int playerId) 
    {
        var user = UsersData.FindUserByTheirToken(token);
        int targetUserId = user.userId;
        if(CreationTeam.isSelectedPlayerInMyTeam(user.userId, playerId))
        {
            CreationTeam.RemovePlayer(targetUserId,playerId);
            Cash.returnMoneyToUser(user, playerId);
            return true;
        }

        return false;
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

    public static bool isChangingRoleSuccessful(string token, int firstPlayerId , int secondPlayerId)
    {
        var user = UsersData.FindUserByTheirToken(token);
        if (CreationTeam.isSelectedPlayerInMyTeam(user.userId, firstPlayerId)&&(CreationTeam.isSelectedPlayerInMyTeam(user.userId, secondPlayerId)) )
        {
            CreationTeam.changeRoleOfPlayer(user.userId, firstPlayerId,secondPlayerId);
            return true;
        }
    
        return false;
    }

}