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
            foreach ( var player in db.playerTable)
            {
                if (inputId == player.id)
                    return player;
            }
        }

        return null;
    }

    public static List<Player> selectedPlayersTeamList(int userId , Player.Team targetTeam)
    {
        List<int> listOfPlIds = CreationTeam.listOfUserTeamPlayerIds(userId);
        List<Player> TeamList = new List<Player>();
        using (var db = new DataBase())
        {
            foreach (var player in db.playerTable )
            {
                foreach (var id in listOfPlIds)
                {
                    if (player.id == id) // find user team players 
                    {
                        if(targetTeam==player.team)
                        TeamList.Add(player);
                    }
                }
            }
        }

        return TeamList;
    }
    
    public static List<Player> selectedPlayersPostList(int userId , Player.Post targetPost )
    {
        List<int> listOfPlIds =CreationTeam.listOfUserTeamPlayerIds(userId);
        List<Player> postList = new List<Player>();
        using (var db = new DataBase())
        {
            foreach (var player in db.playerTable )
            {
                foreach (var id in listOfPlIds)
                {
                    if (player.id == id)
                    {
                        postList.Add(player);
                    }
                }
            }
        }

        return postList;
    }
}
