using System.Threading;
namespace SignUPAndLoginSection.presentationLayer;

public class ScoreBoard
{
    public static List<presentationLayer.User> showScoresTableAPI()
    {
        List<presentationLayer.User> scoresList = DataAccessLayer.ScoreBoard.GetUserScores();
        return scoresList;
    }
}