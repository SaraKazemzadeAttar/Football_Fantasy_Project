using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
using Ubiety.Dns.Core.Records;


using SignUPAndLoginSection.DataAccessLayer;

public class UsersTeamPlayers
{
    [Key] public static int UsersTeamPlayersId { get; set; }

    public static int userId { get; set; }

    public static int playerId { get; set; }

    public static bool isMainPlayer { get; set; }
}
public class CreationTeam
{
    public static void insertSelectedPlayerInUserTeam(int targetUserId, int selectedPlayerId)
    {
        using (var db = new DataBase())
        {
            db.UsersTeamPlayersTable.Add(new(UsersTeamPlayers.userId = targetUserId, UsersTeamPlayers.playerId = selectedPlayerId));
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
                    if (UsersTeamPlayers.playerId == selectedPlayerId)
                    {
                        db.UsersTeamPlayersTable.Remove(record);
                        db.SaveChanges();
                    }
                }

            }
        }
    }

    public static void changingRoleOfPlayer(int targetUserId, int selectedPlayerId)
    {
        List<int> teamPlayerIds = listOfUserTeamPlayerIds(UsersTeamPlayers.userId);
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    foreach (var id in teamPlayerIds)
                    {
                        if (record.isMainPLayer)
                        {
                            record.isMainPLayer = false;
                            db.SaveChanges();
                            break;
                        }

                        if (!record.isMainPLayer)
                        {
                            record.isMainPLayer = true;
                            db.SaveChanges();
                            break;
                        }
                    }
                        if (record.isMainPLayer)
                        {
                            record.isMainPLayer = false;
                            db.SaveChanges();
                            break;
                        }

                        if (!record.isMainPLayer)
                        {
                            record.isMainPLayer = true;
                            db.SaveChanges();
                            break;
                        }
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
}
