 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.ComponentModel.DataAnnotations;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;
 using System.Threading;
 using CronNET;
using SignUPAndLoginSection.businessLayer;
using Player = SignUPAndLoginSection.businessLayer.Player;

namespace SignUPAndLoginSection.DataAccessLayer;


public class FootballPlayersData
{

    
    public List<Player> elements ;
    
    public static void insertPlayersInDataBase()
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

    public static Player findPLayerByTheirId(int inputId)
    {
        using (var db = new DataBase())
        {
            foreach ( var player in ListOfPlayers.getListOfPlayers())
            {
                if (inputId == player.id)
                    return player;
            }
        }

        return null;
    }
}
