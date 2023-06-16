using System;
using SignUPAndLoginSection.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using ServiceStack;
using ServiceStack.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.JSInterop.Implementation;
using System.Threading;
using CronNET;

namespace SignUPAndLoginSection.businessLayer;

public class ListOfPlayers
{
    public static List<Player> getListOfPlayers()
    {
        string url = "https://fantasy.premierleague.com/api/bootstrap-static/";

        FootballPlayersData response = url.GetJsonFromUrl().FromJson<FootballPlayersData>();

        return response.elements;
    }
    
    
    
    public List<string> fullName = new List<string>();
    public List<string> FullNameOfPlayers()
    {
        foreach (var player in ListOfPlayers.getListOfPlayers())
        {
            fullName.Add(player.first_name + player.second_name);
        }

        return fullName;
    }
    public  List<string> Searchingmethod(string entry)
    {
        
        List<string> foundNames = new List<string>();
        
        foreach (var playerFullName in fullName)
        {
            if (playerFullName.Contains(entry))
            {
                foundNames.Add(playerFullName);
            }
        }

        return foundNames;

    }

    public static List<Player> sortedDesendingListOfPlayersByPoint(List<Player> players)
    {
        players = getListOfPlayers();
        for (int i = 0; i < players.Count;i++)
        {
            for (int j = i; j < players.Count;j++)
            {
                if (players[i].total_points > players[j].total_points)
                {
                    var temp = players[i];
                    players[i] = players[j ];
                    players[j ] = temp;
                }
            }
        }

        return players;
    }
    public static List<Player> sortedAsecendingListOfPlayersByPoint(List<Player> players)
    {
        players = getListOfPlayers();
        for (int i = 0; i < players.Count;i++)
        {
            for (int j = i; j < players.Count;j++)
            {
                if (players[i].total_points < players[j ].total_points)
                {
                    var temp = players[i];
                    players[i] = players[j ];
                    players[j ] = temp;
                }
            }
        }

        return players;
    }
    public static List<Player> sortedAsecendingListOfPlayersByPrice(List<Player> players)
    {
        players = getListOfPlayers();
        for (int i = 0; i < players.Count;i++)
        {
            for (int j = i; j < players.Count;j++)
            {
                if (players[i].now_cost > players[j].now_cost)
                {
                    var temp = players[i];
                    players[i] = players[j];
                    players[j] = temp;
                }
            }
        }

        return players;
    }
    public static List<Player> sortedDesendingListOfPlayersByPrice(List<Player> players)
    {
        players = getListOfPlayers();
        for (int i = 0; i < players.Count;i++)
        {
            for (int j = i; j < players.Count;j++)
            {
                if (players[i].now_cost < players[j].now_cost)
                {
                    var temp = players[i];
                    players[i] = players[j];
                    players[j] = temp;
                }
            }
        }

        return players;
    }
    
    public static List<Player> FilterByPost(Player.Post post)
    {
        List <Player> players = getListOfPlayers();
        List <Player> posts= null;
        for (int i = 0; i < players.Count; i++)
        {
            if (post.Equals(players[i].element_type))
            {
                posts.Add(players[i]);
            }
        }

        return posts;
    }
    
   
}

public class Player
{
    public string first_name { get; set; }
    [Key]
    public int id{ get; set; }
    public int now_cost{ get; set; }
    public string second_name{ get; set; }
    public int team{ get; set; }
    public int element_type{ get; set; }

    public int total_points{ get; set; }

    //public string photo { get; set; } 

    public enum Post
    {
        Goalkeeper,
        Defender,
        Midfielder,
        Forward
    }
}