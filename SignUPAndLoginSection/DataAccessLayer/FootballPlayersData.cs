using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.businessLayer;

namespace SignUPAndLoginSection.DataAccessLayer;

public class FootballPlayersData
{
    public List<Player> elements =businessLayer.ListOfPlayers.convertPlayersJsonToList() ;

    public void insertPlayersInDataBase()
    {

            using (var db = new DataBase())
            {
                foreach (var player in elements)
                {
                db.playerTable.Add(player);
                db.SaveChanges();
                }
            }
    }
}
