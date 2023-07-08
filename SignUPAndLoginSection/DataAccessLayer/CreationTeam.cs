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
        [Key] public int UsersTeamPlayersId { get; set; }

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
                    if (record.playerId == selectedPlayerId) // doubt????!!!
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
                    //             switch (record.isMainPLayer)
                    //             {
                    //                 case true:
                    //                     record.isMainPLayer = false;
                    //                     db.SaveChanges();
                    //                     break;
                    //                 case false:
                    //                     record.isMainPLayer = true;
                    //                     foreach(var id in listOfUserTeamPlayerIds(userId))
                    //                     db.SaveChanges();
                    //                     break;
                    //             }
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

    public static int numberOfPlayersFromThisTeam(int targetUserId, string playerTeam)
    {
        int counterOfPlayersOfIntendedTeam = 0;
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    var playerInfo = FootballPlayersData.getInfoOfTeamPlayers(targetUserId);
                    foreach (var player in playerInfo)
                        if (playerInfo["Team"] == playerTeam)
                        {
                            counterOfPlayersOfIntendedTeam++;
                        }
                }
            }
        }

        return counterOfPlayersOfIntendedTeam;
    }

    public static bool hasTeamUnderTwoGoalKeepers(int targetUserId)
    {
        int counterOfGoalKeepers = 0;
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    var playerKeyValuePair = FootballPlayersData.getInfoOfTeamPlayers(targetUserId);
                    foreach (var player in playerKeyValuePair)
                        if (playerKeyValuePair["Post"] == "Goalkeeper")
                        {
                            counterOfGoalKeepers++;
                        }
                }
            }

            if (counterOfGoalKeepers < 2)
            {
                return true;
            }

            return false;
        }
    }

    public static bool hasTeamUnderFiveDefenders(int targetUserId)
    {
        int counterOfDefenders = 0;
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    var playerKeyValuePair = FootballPlayersData.getInfoOfTeamPlayers(targetUserId);
                    foreach (var player in playerKeyValuePair)
                    {
                        if (playerKeyValuePair["Post"] == "Defender")
                            counterOfDefenders++;
                    }
                }
            }
        }

        if (counterOfDefenders < 5)
        {
            return true;
        }

        return false;
    }

    public static bool hasTeamUnderFiveMidfielders(int targetUserId)
    {
        int counterOfMidfielders = 0;
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    var playerKeyValuePair = FootballPlayersData.getInfoOfTeamPlayers(targetUserId);
                    foreach (var player in playerKeyValuePair)
                    {
                        if (playerKeyValuePair["Post"] == "Midfielder")
                            counterOfMidfielders++;
                    }
                }
            }
        }

        if (counterOfMidfielders < 5)
        {
            return true;
        }

        return false;
    }

    public static bool hasTeamUnderThreeForwards(int targetUserId)
    {
        int counterOfForwards = 0;
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    var playerKeyValuePair = FootballPlayersData.getInfoOfTeamPlayers(targetUserId);
                    foreach (var player in playerKeyValuePair)
                    {
                        if (playerKeyValuePair["Post"] == "Forward")
                            counterOfForwards++;
                    }
                }
            }
        }

        if (counterOfForwards < 3)
        {
            return true;
        }

        return false;
    }
}
