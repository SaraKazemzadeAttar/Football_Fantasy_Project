namespace SignUPAndLoginSection.presentationLayer;

public class ScoreTable

{
        public static IResult ShowScoresTableAPI()
        {
            List<presentationLayer.User> scoresList = businessLayer.ScoreTable.GetUserScores();
            return Results.Ok(scoresList);
        }
    
}