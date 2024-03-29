using System;
using ServiceStack;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection.businessLayer;

public class TeamPlayersSelection
{
    public static bool isOmittingPlayerSuccessful(string token ,int playerId) 
    {
        var user = UsersData.FindUserByTheirToken(token);
        int targetUserId = user.userId;
        if(CreationTeam.isSelectedPlayerInMyTeam(user.userId, playerId))
        {
            DataAccessLayer.Cash.returnMoneyToUser(user, playerId);
            CreationTeam.RemovePlayer(targetUserId,playerId);
            return true;
        }

        return false;
    }

    public static bool isSettingSubstitutePlayerSuccessful(string token, int playerId)
    {
        var user = UsersData.FindUserByTheirToken(token);
        if (CreationTeam.isSelectedPlayerInMyTeam(user.userId, playerId))
        {
            CreationTeam.setTheSubstitutePlayer(user.userId, playerId);
            return true;
        }

        return false;
    }
    
    public static bool isChangingRoleSuccessful(string token, int firstPlayerId , int secondPlayerId)
    {
        var user = UsersData.FindUserByTheirToken(token);
        if (CreationTeam.isSelectedPlayerInMyTeam(user.userId, firstPlayerId)&&(CreationTeam.isSelectedPlayerInMyTeam(user.userId, secondPlayerId)) )
        {
            CreationTeam.changeRoleForBothPlayers(user.userId, firstPlayerId,secondPlayerId);
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
                return (ListOfMyTeamPlayers.selectedPlayersPostList(targetUserId, Post.Goalkeeper).Count < 2);
            case Post.Defender:
                return (ListOfMyTeamPlayers.selectedPlayersPostList(targetUserId, Post.Defender).Count < 5);
            case Post.Midfielder:
                return ListOfMyTeamPlayers.selectedPlayersPostList(targetUserId, Post.Midfielder).Count < 5;
            case Post.Forward:
                return ListOfMyTeamPlayers.selectedPlayersPostList(targetUserId, Post.Forward).Count < 3;
            default:
                return false;
        }
    }
    
    public static bool AreUnderFourPlayersFromOneTeam(int targetUserId,Player selectedPlayer)
    {
        var playerTeam = selectedPlayer.team;
        
        if (ListOfMyTeamPlayers.selectedPlayersTeamList(targetUserId ,playerTeam).Count > 4)
        {
            return false;
        }
    
        return true;
    }

    public static List<string> ShowListOfMyTeam(string token)
    {
        var user = UsersData.FindUserByTheirToken(token);
        return ListOfMyTeamPlayers.showListOfMyTeam(user.userId);
    }
}