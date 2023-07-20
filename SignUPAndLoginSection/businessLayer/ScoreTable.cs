using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.businessLayer;

public static class ScoreTable
{
    public static List<presentationLayer.User> GetUserScores()
    {
        List<presentationLayer.User> usersScores = new List<presentationLayer.User>();
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                double score = DataAccessLayer.ScoreTable.scoreCalculation(user.userId);
                usersScores.Add(new presentationLayer.User { userName = user.userName, Score = score });
            }
        }
        return usersScores;
    }

}