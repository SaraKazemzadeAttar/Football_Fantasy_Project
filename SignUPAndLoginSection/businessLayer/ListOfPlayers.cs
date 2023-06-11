using System;
using SignUPAndLoginSection.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using ServiceStack;
using ServiceStack.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace SignUPAndLoginSection.businessLayer;

public class ListOfPlayers
{
    public static List<Player> getListOfPlayers()
    {
        string url = "https://fantasy.premierleague.com/api/bootstrap-static/";

        FootballPlayersData response = url.GetJsonFromUrl().FromJson<FootballPlayersData>();

        return response.elements;
    }
}

public class Player
{
    public string first_name;
    public int id;
    public int now_cost;
    public string second_name;
    public int team;
    public int element_type;

    public int total_points;
    // photo ->string
    
    
}