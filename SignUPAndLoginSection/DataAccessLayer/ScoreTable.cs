using System.Collections;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection.DataAccessLayer;

public class ScoreTable
{
    public static List<int> mainTaemPlayersIds(int targetUserId)
    {
        List<int> mainPlayersList = new List<int>();
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    if (record.isMainPlayer)
                    {
                        mainPlayersList.Add(record.playerId);
                    }
                }
            }
        }

        return mainPlayersList;
    }

    public static double ListOfMainPlayerCosts(int userId)
    {
        List<int> mainPlayerIds = mainTaemPlayersIds(userId);
        double mainPlayersListcost = 0;
        using (var db = new DataBase())
        {
            foreach (var id in mainPlayerIds)
            {
                foreach (var player in db.playerTable)
                {
                    if (player.id == id)
                    {
                        mainPlayersListcost = mainPlayersListcost + player.now_cost;
                    }
                }
            }
        }

        return mainPlayersListcost;
    }
    
    public static List<int> secondaryTaemPlayersIds(int targetUserId)
    {
        List<int> secondaryPlayersList = new List<int>();
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    if (record.isMainPlayer)
                    {
                        secondaryPlayersList.Add(record.playerId);
                    }
                }
            }
        }

        return secondaryPlayersList;
    }
    
    public static double ListOfSecondaryPlayerCosts(int userId)
    {
        List<int> secondaryPlayerIds = secondaryTaemPlayersIds(userId);
        double secondaryPlayersListcost = 0;
        using (var db = new DataBase())
        {
            foreach (var id in secondaryPlayerIds)
            {
                foreach (var player in db.playerTable)
                {
                    if (player.id == id)
                    {
                        secondaryPlayersListcost = secondaryPlayersListcost + player.now_cost;
                    }
                }
            }
        }

        return secondaryPlayersListcost;
    }

    public static double scoreCalculation(int userId)
    {
        double finallScore = ListOfSecondaryPlayerCosts(userId) + 2*ListOfMainPlayerCosts(userId);
        return finallScore;
    }

    public static List<string> usersTable()
    {
        List<string> usersScores = new List<string>();
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                usersScores.Add(user.userName + scoreCalculation(user.userId).ToString());
            }
        }

        return usersScores;
    }
}





            
        
    


