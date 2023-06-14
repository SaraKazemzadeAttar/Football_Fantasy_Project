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
            for (int j = 0; j < players.Count;j++)
            {
                if (players[j].total_points > players[j + 1].total_points)
                {
                    var temp = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = temp;
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
            for (int j = 0; j < players.Count;j++)
            {
                if (players[j].total_points < players[j + 1].total_points)
                {
                    var temp = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = temp;
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
            for (int j = 0; j < players.Count;j++)
            {
                if (players[j].now_cost > players[j + 1].now_cost)
                {
                    var temp = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = temp;
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
            for (int j = 0; j < players.Count;j++)
            {
                if (players[j].now_cost < players[j + 1].now_cost)
                {
                    var temp = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = temp;
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