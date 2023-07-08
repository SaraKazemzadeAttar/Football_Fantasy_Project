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

    public static Player findPlayerByTheirName(string name)
    {
        using (var db = new DataBase())
        {
            foreach ( var player in db.playerTable )
            {
                if (name == player.first_name|| name==player.second_name)
                    return player;
            }
        }

        return null;
    }



    public static Dictionary<string, string>  getInfoOfTeamPlayers(int userId)
    {
        List<int> listOfPlIds = UsersTeamPlayers.listOfUserTeamPlayerIds(userId);
        Dictionary<string, string> PlayerList = new Dictionary<string, string>();
        foreach (var teamPlayerId in listOfPlIds) // players who the user selected
        {
            using (var db = new DataBase())
            {
                foreach (var player in db.playerTable) // find player in player table to get their info
                {
                    if (player.id == teamPlayerId)
                    {
                        PlayerList.Add("Team",player.team.ToString() );
                        PlayerList.Add("Post",player.element_type.ToString());
                        PlayerList.Add("NowCost",player.now_cost.ToString() );
                        PlayerList.Add("FullName",player.first_name+player.second_name);
                        PlayerList.Add("TotalPoints" , player.total_points.ToString());
                    }
                }
            }
        }
        return PlayerList;
    }
}
