 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.ComponentModel.DataAnnotations;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;
 using System.Threading;
 using System.Collections.Generic;
 using CronNET;
 using NUnit.Framework;
 using SignUPAndLoginSection.businessLayer;

 namespace SignUPAndLoginSection.DataAccessLayer;

public class FootballFanatasyAPIResponse
{
    public List<Player> elements { get; set; }
}

public class FootballPlayersData
{

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

    public static void clearRecordsOfPlayerTable()
    {

        using (var db = new DataBase())
        {
            foreach ( var player in db.playerTable)
            {
                db.playerTable.Remove(player);
                db.SaveChanges();
            }
        }
    }
    
    public static Player findPLayerByTheirId(int inputId)
    {
        using (var db = new DataBase())
        {
            foreach ( var player in db.playerTable)
            {
                if (inputId == player.id)
                    return player;
            }
        }

        return null;
    }
    
    public static List<Player> findPlayerByName(string input)
    {
        List <Player> foundNames = new List <Player>();
        
        using (var db = new DataBase())
        {
            foreach (var player in db.playerTable)
            {
                if (player.first_name.Contains(input) || player.second_name.Contains(input))
                {
                    foundNames.Add(player);
                }
            }
        }

        return foundNames;
    }
    
   
    
    }
