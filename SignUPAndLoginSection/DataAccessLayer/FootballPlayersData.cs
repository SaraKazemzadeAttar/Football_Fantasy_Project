using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SignUPAndLoginSection.DataAccessLayer;

using SignUPAndLoginSection.businessLayer;

namespace SignUPAndLoginSection.DataAccessLayer;

public class FootballPlayersData
{
    public List<Player> elemٍents;

    public void insertPlayersInDataBase()
    {
        foreach (var player in elemٍents)
        {
            using (var db = new DataBase())
            {
                db.playerTable.Add(player);
                db.SaveChanges();
            }
        }
    }
}
