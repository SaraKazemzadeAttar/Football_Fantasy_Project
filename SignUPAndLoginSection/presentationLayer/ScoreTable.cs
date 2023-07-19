namespace SignUPAndLoginSection.presentationLayer;

public class ScoreTable
{
    public static List<string> showScoresTableAPI()
    {
        return businessLayer.ScoreTable.usersTable();
    }
}