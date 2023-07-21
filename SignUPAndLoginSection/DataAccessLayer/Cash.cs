using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.presentationLayer;


namespace SignUPAndLoginSection.DataAccessLayer;

public class Cash
{
    public static void setInitialCashForUser(presentationLayer.User u)
    {
        u.cash = 1000;
    }
    
    public static void buySelectedPlayer(presentationLayer.User user, int playerId)
    {
        Player convertedPl = FootballPlayersData.findPLayerByTheirId(playerId);
        using (var db = new DataBase())
        {
            foreach (var u in db.userTable)
            {
                if (user.userId == u.userId)
                {
                    u.cash -= convertedPl.now_cost;
                    db.SaveChanges();
                }
            }
        }

        CreationTeam.insertSelectedPlayerInUserTeam(user.userId,playerId);
    }
    
    public static void returnMoneyToUser(presentationLayer.User user, int playerId)
    {
        Player convertedPl = FootballPlayersData.findPLayerByTheirId(playerId);
        using (var db = new DataBase())
        {
            foreach (var u in db.userTable)
            {
                if (user.userId == u.userId)
                {
                    u.cash += convertedPl.now_cost;
                    db.SaveChanges();
                }
            }
        }
    }
    
    public static bool hasUserEnoughMoney(presentationLayer.User user, Player selectedPlayer)
    {
        if (user.cash <selectedPlayer.now_cost)
        {
            return false;
        }
    
        return true;
    }
}