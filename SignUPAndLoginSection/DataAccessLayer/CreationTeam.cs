using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
using Ubiety.Dns.Core.Records;
using User = SignUPAndLoginSection.presentationLayer.User;


namespace SignUPAndLoginSection.DataAccessLayer;


public class UsersTeamPlayers
{

    [Key] public int UsersTeamPlayersId { get; set; }

    public int userId { get; set; }

    public int playerId { get; set; }

    public RoleOfPlayer roleOfPLayer { get; set; }
}

public enum RoleOfPlayer
{
    MainPlayer=0,
    SubstitutePlayer=1
}

public class CreationTeam
{
    public static void insertSelectedPlayerInUserTeam(int targetUserId, int selectedPlayerId)
    {
        using (var db = new DataBase())
        {
            db.UsersTeamPlayersTable.Add(new UsersTeamPlayers() { userId = targetUserId, playerId = selectedPlayerId });
            db.SaveChanges();
        }
    }

    public static void RemovePlayer(int targetUserId, int selectedPlayerId)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    if (record.playerId == selectedPlayerId)
                    {
                        db.UsersTeamPlayersTable.Remove(record);
                        db.SaveChanges();
                    }
                }

            }
        }
    }

    public static bool isSelectedPlayerInMyTeam(int targetUserId, int selectedPlayerId)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId && record.playerId == selectedPlayerId)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static void setTheMainPlayer(int targetUserId, int selectedPlayerId)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    if (record.playerId == selectedPlayerId)
                    {
                        record.roleOfPLayer = RoleOfPlayer.MainPlayer;
                        db.SaveChanges();
                    }
                }
            }
        }
    }

    public static void setTheSubstitutePlayer(int targetUserId, int selectedPlayerId)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    if (record.playerId == selectedPlayerId)
                    {
                        record.roleOfPLayer = RoleOfPlayer.SubstitutePlayer;
                        db.SaveChanges();
                    }
                }
            }
        }
    }

    // public static void changeRoleOfPlayer(int UTPId)
    // {
    //     using (var db = new DataBase())
    //     {
    //         foreach (var record in db.UsersTeamPlayersTable)
    //         {
    //             if (record.UsersTeamPlayersId == UTPId)
    //             {
    //                 if (record.roleOfPLayer == RoleOfPlayer.MainPlayer)
    //                 {
    //                     setTheSubstitutePlayer(record.userId, record.playerId);
    //                     db.SaveChanges();
    //                     return;
    //                 }
    //                 else
    //                 {
    //                     setTheMainPlayer(record.userId, record.playerId);
    //                     db.SaveChanges();
    //                     return;
    //                 }
    //             }
    //         }
    //     }
    // }
    //
    //
    //
    // public static void changeRoleForBothPlayers(int targetUserId, int firstPlayerId, int secondPlayerId)
    // {
    //     using (var db = new DataBase())
    //     {
    //         foreach (var record in db.UsersTeamPlayersTable)
    //         {
    //             if (record.userId == targetUserId)
    //             {
    //                 if (record.playerId == firstPlayerId)
    //                 {
    //                     changeRoleOfPlayer(record.UsersTeamPlayersId);
    //                 }
    //
    //                 if (record.playerId == secondPlayerId)
    //                 {
    //                     changeRoleOfPlayer(record.UsersTeamPlayersId);
    //                 }
    //             }
    //         }
    //     }
    // }

    public static void changeRoleForBothPlayers(int targetUserId, int firstPlayerId, int secondPlayerId)
    {
        List<UsersTeamPlayers> UTPMainPlayers = ListOfMyTeamPlayers.myMainPlayersList(targetUserId);
        List<UsersTeamPlayers> UTPSubstitutePlayers = ListOfMyTeamPlayers.mySubstitutePlayersList(targetUserId);
        foreach (var record in UTPSubstitutePlayers)
        {
            if (record.playerId == firstPlayerId || record.playerId==secondPlayerId)
            {
                setTheMainPlayer(record.userId, record.playerId);
            }
        }
        foreach (var record in UTPMainPlayers)
        {
            if (record.playerId == firstPlayerId || record.playerId==secondPlayerId)
            {
                setTheSubstitutePlayer(record.userId, record.playerId);
            }
        }
    }
}