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

namespace SignUPAndLoginSection.businessLayer;

public class ListOfPlayers
{
    public static List<Player> getListOfPlayers()
    {
        string url = "https://fantasy.premierleague.com/api/bootstrap-static/";

        FootballPlayersData response = url.GetJsonFromUrl().FromJson<FootballPlayersData>();

        return response.elements;
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
    
    

    
}

public class Player
{
    public string first_name;
    [Key]
    public int id;
    public int now_cost;
    public string second_name;
    public int team;
    public int element_type;

    public int total_points;
    // photo ->string
}