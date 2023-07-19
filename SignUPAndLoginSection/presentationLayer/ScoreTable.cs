namespace SignUPAndLoginSection.presentationLayer;

public class ScoreTable
{
    public static IResult showScoresTableAPI()
    {
        List<string> scoresList = businessLayer.ScoreTable.usersTable();
        return Results.Ok(new
        {
            scoresList
        });
    }
}