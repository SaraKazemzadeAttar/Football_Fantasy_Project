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

    public bool isMainPlayer { get; set; }
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

    public static Post getPostOfChangingRole(int selectedPlayerId)
    {
        Player convertedPl = FootballPlayersData.findPLayerByTheirId(selectedPlayerId);
        return convertedPl.element_type;
    }
    public static UsersTeamPlayers getSubstitutePlayerOfSelectedPost(int targetUserId,int  selectedPlayerId)
    {
        List<Player> intendedPostPlayers=FootballPlayersData.selectedPlayersPostList(targetUserId,getPostOfChangingRole(selectedPlayerId));
        using (var db = new DataBase())
        {
            foreach (var sPostPlayer in intendedPostPlayers) 
            {
                foreach (var utPlayer in db.UsersTeamPlayersTable) 
                {
                    if (sPostPlayer.id == utPlayer.playerId) 
                    {
                        if (!utPlayer.isMainPlayer)
                        {
                            return utPlayer;
                        }
                    }
                }
            }
        }

        return null;
    }

    public static UsersTeamPlayers getMainPlayerOfSelectedPost(int targetUserId, int selectedPlayerId)
    {
        List<Player> intendedPostPlayers=FootballPlayersData.selectedPlayersPostList(targetUserId,getPostOfChangingRole(selectedPlayerId));
        using (var db = new DataBase())
        {
            foreach (var utPlayer in db.UsersTeamPlayersTable)
            {
                if (utPlayer.playerId == selectedPlayerId)
                {
                    return utPlayer;
                }
            }
        }

        return null;
    }

    public static void changingRoleOfSubstitutePlayer(int targetUserId,int  selectedPlayerId)
    {
        UsersTeamPlayers substitutePlayer = getSubstitutePlayerOfSelectedPost(targetUserId,selectedPlayerId);
        substitutePlayer.isMainPlayer = false;
    }
    
    public static void changingRoleOfMainPlayer(int targetUserId, int selectedPlayerId)
    {
        UsersTeamPlayers MainPlayer = getMainPlayerOfSelectedPost(targetUserId, selectedPlayerId);
        MainPlayer.isMainPlayer = false;
    }

    public static List<int> listOfUserTeamPlayerIds(int targetUserId)
    {
        List<int> listOfSelectedPlayersIds = new List<int>();
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    listOfSelectedPlayersIds.Add(record.playerId);
                }
            }
        }

        return listOfSelectedPlayersIds;
    }
}