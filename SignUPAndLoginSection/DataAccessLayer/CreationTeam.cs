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
    public static bool isPlayerUniqueInMyTeam(int targetUserId, int selectedPlayerId)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId && record.playerId == selectedPlayerId)
                {
                    return false;
                }
            }
        }

        return true;
    }

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

    public static UsersTeamPlayers getSubstitutePlayerOfSelectedPost(int targetUserId, int selectedPlayerId)
    {
        List<Player> intendedPostPlayers =
            FootballPlayersData.selectedPlayersPostList(targetUserId, getPostOfChangingRole(selectedPlayerId));
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
        List<Player> intendedPostPlayers =
            FootballPlayersData.selectedPlayersPostList(targetUserId, getPostOfChangingRole(selectedPlayerId));
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

    public static void changingRoleOfSubstitutePlayer(int targetUserId, int selectedPlayerId)
    {
        UsersTeamPlayers substitutePlayer = getSubstitutePlayerOfSelectedPost(targetUserId, selectedPlayerId);
        using (var db = new DataBase())
        {
            foreach (var utPlayer in db.UsersTeamPlayersTable)
            {
                if (substitutePlayer == utPlayer)
                {
                    substitutePlayer.isMainPlayer = false;
                    db.SaveChanges();
                }
            }
        }
    }

    public static void changingRoleOfMainPlayer(int targetUserId, int selectedPlayerId)
    {
        UsersTeamPlayers MainPlayer = getMainPlayerOfSelectedPost(targetUserId, selectedPlayerId);
        using (var db = new DataBase())
        {
            foreach (var utPlayer in db.UsersTeamPlayersTable)
            {
                if (MainPlayer == utPlayer)
                {
                    MainPlayer.isMainPlayer = false;
                    db.SaveChanges();
                }
            }
        }
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

    public static List<string> showListOfMyTeam(int userId)
    {
        string playerInfo = "";
        List<int> listOfSelectedPlayersIds = listOfUserTeamPlayerIds(userId);
        List<string> listOfplayersInfo = new List<string>();
        using (var db = new DataBase())
        {
            foreach (var player in db.playerTable)
            {
                foreach (var playerId in listOfSelectedPlayersIds)
                {
                    if (playerId == player.id)
                    {
                        listOfplayersInfo.Add("FullName : "+player.first_name + " " + player.second_name + "   Price :" + player.now_cost + "   Post :" +
                                                     player.element_type + "   Team :" + player.team);
                    }
                }
            }

        }

        return listOfplayersInfo;
    }

    public static bool isSelectedPlayerInMyTeam(int targetUserId, int selectedPlayerId)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    if (record.playerId == selectedPlayerId)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

    public static void changeRoleOfPlayer(int targetUserId, int firstPlayerId , int secondPlayerId )
    {       
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    if (record.playerId == firstPlayerId || record.playerId==secondPlayerId)
                    {
                        if (record.isMainPlayer)
                        {
                            record.isMainPlayer = false;
                            db.SaveChanges();
                        }
                        else
                        {
                            record.isMainPlayer = true;
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}