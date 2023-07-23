using System.Threading;
namespace SignUPAndLoginSection.presentationLayer;

public class ScoreBoard
{
    public static List<User> showScoresTableAPI()
    {
        List<User> scoresList = DataAccessLayer.ScoreBoard.GetUserScores();
        return scoresList;
    }
}