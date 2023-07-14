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
using System.Diagnostics;
using Microsoft.JSInterop.Implementation;
using System.Threading;
using CronNET;

namespace SignUPAndLoginSection.businessLayer;

public class ListOfPlayers
{
    public static List<string> fullName = new List<string>();
    
    public static List<Player> getListOfPlayers()
    {
        string url = "https://fantasy.premierleague.com/api/bootstrap-static/";

        FootballFanatasyAPIResponse response = url.GetJsonFromUrl().FromJson<FootballFanatasyAPIResponse>();

        return response.elements;
    }
    
    
    public static List<string> FullNameOfPlayers()
    {
        foreach (var player in ListOfPlayers.getListOfPlayers())
        {
            fullName.Add(player.first_name + player.second_name);
        }

        return fullName;
    }
    
    public static List<string> searchingMethod(string entry)
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

    public static List<Player> sortedDescendingListOfPlayersByPoint(List<Player> players)
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
    
    public static List<Player> sortedAscendingListOfPlayersByPoint(List<Player> players)
    {
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
    
    public static List<Player> sortedAscendingListOfPlayersByPrice(List<Player> players)
    {
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
    
    public static List<Player> sortedDescendingListOfPlayersByPrice(List<Player> players)
    {
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
    
    public static List<Player> FilterByPost(Post post,List <Player> players)
    {
        List <Player> posts= new List<Player>();
        for (int i = 0; i < players.Count; i++)
        {
            if (post.Equals(players[i].element_type))
            {
                posts.Add(players[i]);
            }
        }

        return posts;
    }

    public static List<Player> FilterPlayers(int? filter)
    {
        List<Player> players = getListOfPlayers();
        switch (filter)
        {
            case 1:
                return sortedDescendingListOfPlayersByPoint(players);
            case 2:
                return sortedAscendingListOfPlayersByPoint(players);
            case 3:
                return sortedAscendingListOfPlayersByPrice(players);
            case 4:
                return sortedDescendingListOfPlayersByPrice(players);
            default:
                return null;
        }
    }

    public static List<Player> FilterPlayersByPost(int? post )
    {
        List<Player> players = getListOfPlayers();
        Post playersPost=(Post)post;
        
            return FilterByPost(playersPost ,players);
       
    }
    
}

public class Player
{
    public string first_name { get; set; }
    [Key]
    public int id{ get; set; }
    public double now_cost{ get; set; }
    public string second_name{ get; set; }
    public Team team{ get; set; }
    public Post element_type{ get; set; }
    public double total_points{ get; set; }

    public string photo { get; set; } 
    
}
public enum Post
{
    Goalkeeper,
    Defender,
    Midfielder,
    Forward
}

public enum Team
{
    Arsenal,
    AstonVilla,
    Bournemouth,
    Brentford,
    Brighton,
    Chelsea,
    CrystalPalace,
    Everton,
    Fulham,
    Leicester,
    Leeds,
    Liverpool,
    ManCity,
    ManUtd,
    Newcastle,
    Nott_m_Forest,
    Southampton,
    Spurs,
    WestHam,
    Wolves
}