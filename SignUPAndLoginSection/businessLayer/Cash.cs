using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.businessLayer;

public class Cash
{
    public static void buySelectedPlayer(presentationLayer.User user, int playerId)
    {
        CreationTeam.insertSelectedPlayerInUserTeam(user.userId,playerId);
        Player convertedPl = FootballPlayersData.findPLayerByTheirId(playerId);
        user.cash =- convertedPl.now_cost;
    }
    
    public static void returnMoneyToUser(presentationLayer.User user, int playerId)
    {
        Player convertedPl = FootballPlayersData.findPLayerByTheirId(playerId);
        user.cash =+ convertedPl.now_cost;
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