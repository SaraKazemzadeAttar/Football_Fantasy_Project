using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.businessLayer;

public static class ScoreTable
{
    public static List<UserScore> GetUserScores()
    {
        List<UserScore> usersScores = new List<UserScore>();
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                double score = DataAccessLayer.ScoreTable.scoreCalculation(user.userId);
                usersScores.Add(new UserScore { Name = user.userName, Score = score });
            }
        }

        return usersScores;
    }

    public class UserScore
    {
        public string Name { get; set; }
        public double Score { get; set; }
    }

 
    
    
    


}