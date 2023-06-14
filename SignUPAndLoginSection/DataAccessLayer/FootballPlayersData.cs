 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.ComponentModel.DataAnnotations;
using SignUPAndLoginSection.Model;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.businessLayer;
using Player = SignUPAndLoginSection.businessLayer.Player;

namespace SignUPAndLoginSection.DataAccessLayer;

public class FootballPlayersData
{
    public List<Player> elements ;
    
    public void insertPlayersInDataBase()
    {

            using (var db = new DataBase())
            {
                foreach ( var player in ListOfPlayers.getListOfPlayers())
                {
                db.playerTable.Add(player);
                db.SaveChanges();
                }
            }
    }
   
}
