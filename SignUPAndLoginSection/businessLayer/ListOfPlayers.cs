using System;
using SignUPAndLoginSection.DataAccessLayer;
namespace SignUPAndLoginSection.businessLayer;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using ServiceStack;
using ServiceStack.Text;
using System.Text.Json;
using System.Collections.Generic;

public class ListOfPlayers
{
    public static Object callListOfPlayersAPI()
    {
        string url = "https://fantasy.premierleague.com/api/bootstrap-static/";

        FootballPlayersData FootBallData = url.GetJsonFromUrl().FromJson<FootballPlayersData>();

        return FootBallData.elements;
    }

    public List<Player> convertPlayersJsonToList()
    {
        var listOfPlayers = JsonConvert.DeserializeObject<List<Player>>(callListOfPlayersAPI);
        return listOfPlayers;
    }

}