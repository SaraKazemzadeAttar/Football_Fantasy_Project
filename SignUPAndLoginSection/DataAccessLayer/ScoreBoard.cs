namespace SignUPAndLoginSection.DataAccessLayer;

public class ScoreBoard
{
    public static List<presentationLayer.User> GetUserScores()
    {
        List<presentationLayer.User> usersScores = new List<presentationLayer.User>();
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                double score = ScoreTable.scoreCalculation(user.userId);
                user.score = score;
                db.SaveChanges();
                usersScores.Add(new presentationLayer.User { fullName = user.fullName, score = user.score});
            }
        }
        return usersScores;
    }
}