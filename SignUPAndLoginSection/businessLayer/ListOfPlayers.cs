using System;
using SignUPAndLoginSection.DataAccessLayer;
namespace SignUPAndLoginSection.businessLayer;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using ServiceStack;
using ServiceStack.Text;

public class ListOfPlayers
{
    public static Object callListOfPlayersAPI()
    {
        string url = "https://fantasy.premierleague.com/api/bootstrap-static/";

        var FootBallData = url.GetJsonFromUrl().FromJson<FootballPlayersData>();
        return FootBallData.elemٍents;
    }

}