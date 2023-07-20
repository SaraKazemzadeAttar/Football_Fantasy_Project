namespace SignUPAndLoginSection.presentationLayer;

public class ScoreTable

{
        public static IResult ShowScoresTableAPI()
        {
            List<businessLayer.ScoreTable.UserScore> scoresList = businessLayer.ScoreTable.GetUserScores();
            return Results.Ok(scoresList);
        }


    
}