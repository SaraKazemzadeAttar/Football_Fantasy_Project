namespace SignUPAndLoginSection.presentationLayer;

public class ScoreBoard
{
    
    public static IResult ShowScoresTableAPI()
    {
        List<presentationLayer.User> scoresList = DataAccessLayer.ScoreBoard.GetUserScores();
        return Results.Ok(scoresList);
    }
}