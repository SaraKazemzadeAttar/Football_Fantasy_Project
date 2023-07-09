using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
using Ubiety.Dns.Core.Records;


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

    public static void changingRoleOfPlayer(int targetUserId, int selectedPlayerId) // the owner of playerId is a main player
    {
        List<int> teamPlayerIds = listOfUserTeamPlayerIds(targetUserId);
        using (var db = new DataBase())
        {
            foreach (var id in teamPlayerIds) // user team players
            {
                if (id == selectedPlayerId) // find player
                {
                    Player convertedPl = FootballPlayersData.findPLayerByTheirId(selectedPlayerId);
                    var intendedPost = convertedPl.element_type;
                    List<Player> intendedPostPlayers=FootballPlayersData.selectedPlayersPostList(targetUserId, intendedPost);
                    foreach(var sPostPlayer in intendedPostPlayers) // players of same post in user team
                    {
                        foreach (var utPlayer in db.UsersTeamPlayersTable) // to access field isMainPlayer
                        {
                            if (sPostPlayer.id == utPlayer.playerId)
                            {
                                if (!utPlayer.isMainPlayer)
                                {
                                    utPlayer.isMainPlayer = true;
                                }
                            }

                            if (utPlayer.playerId == convertedPl.id)
                            {
                                utPlayer.isMainPlayer = false;
                            }
                        }
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