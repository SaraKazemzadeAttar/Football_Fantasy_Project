using System.Collections;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;

namespace SignUPAndLoginSection.DataAccessLayer;

public class ScoreTable
{
    public static List<int> mainTeamPlayersIds(int targetUserId)
    {
        List<int> mainPlayersList = new List<int>();
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    if (record.roleOfPLayer==RoleOfPlayer.MainPlayer)
                    {
                        mainPlayersList.Add(record.playerId);
                    }
                }
            }
        }

        return mainPlayersList;
    }

    public static double ListOfMainPlayerScores(int userId)
    {
        List<int> mainPlayerIds = mainTeamPlayersIds(userId);
        double mainPlayersScoresList = 0;
        using (var db = new DataBase())
        {
            foreach (var id in mainPlayerIds)
            {
                foreach (var player in db.playerTable)
                {
                    if (player.id == id)
                    {
                        mainPlayersScoresList += player.total_points;
                    }
                }
            }
        }

        return mainPlayersScoresList;
    }
    
    public static List<int> substituteTeamPlayersIds(int targetUserId)
    {
        List<int> secondaryPlayersList = new List<int>();
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    if (record.roleOfPLayer==RoleOfPlayer.SubstitutePlayer)
                    {
                        secondaryPlayersList.Add(record.playerId);
                    }
                }
            }
        }

        return secondaryPlayersList;
    }
    
    public static double ListOfSecondaryPlayerScores(int userId)
    {
        List<int> secondaryPlayerIds = substituteTeamPlayersIds(userId);
        double secondaryPlayersScoresList = 0;
        using (var db = new DataBase())
        {
            foreach (var id in secondaryPlayerIds)
            {
                foreach (var player in db.playerTable)
                {
                    if (player.id == id)
                    {
                        secondaryPlayersScoresList += player.total_points;
                    }
                }
            }
        }

        return secondaryPlayersScoresList;
    }

    public static double scoreCalculation(int userId)
    {
        double finalScore = ListOfSecondaryPlayerScores(userId) + 2*ListOfMainPlayerScores(userId);
        return finalScore;
    }
    
}





            
        
    


