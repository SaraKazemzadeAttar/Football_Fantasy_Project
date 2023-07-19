using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.businessLayer;

public static class ScoreTable
{
    public static List<string> usersTable()
    {
        List<string> usersScores = new List<string>();
        using (var db = new DataBase())
        {
            foreach (var user in db.userTable)
            {
                usersScores.Add(user.userName + DataAccessLayer.ScoreTable.scoreCalculation(user.userId).ToString());
            }
        }

        return usersScores;
    }
    
    
    
    


}