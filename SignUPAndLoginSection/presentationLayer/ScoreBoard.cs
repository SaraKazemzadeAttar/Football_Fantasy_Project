using System.Threading;
namespace SignUPAndLoginSection.presentationLayer;

public class ScoreBoard
{
    public static void showScoresTableWeeklyAPI()
    {
        var now = DateTime.Now;
        var nextWeek = now.AddDays(7);
        var durationUntilWeekDate = nextWeek.Date - now;

        var t = new Timer(o => { showScoresTableAPI();}, null, TimeSpan.Zero, durationUntilWeekDate);
        //t.Change(0,100);
    }

    public static List<presentationLayer.User> showScoresTableAPI()
    {
        List<presentationLayer.User> scoresList = DataAccessLayer.ScoreBoard.GetUserScores();
        return scoresList;
    }
}