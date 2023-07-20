using SignUPAndLoginSection.businessLayer;

namespace SignUPAndLoginSection.DataAccessLayer;

public class ListOfMyTeamPlayers
{
    public static bool isPlayerUniqueInMyTeam(int targetUserId, int selectedPlayerId)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId && record.playerId == selectedPlayerId)
                {
                    return false;
                }
            }
        }

        return true;
    }
    
    public static List<int> listOfUserTeamPlayerIds(int targetUserId)
    {
        List<int> listOfSelectedPlayersIds = new List<int>();
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    listOfSelectedPlayersIds.Add(record.playerId);
                }
            }
        }

        return listOfSelectedPlayersIds;
    }

    public static string showInfoOfPlayer(int playerId)
    {
        using (var db = new DataBase())
        {
            foreach (var player in db.playerTable)
            {
                foreach (var utp in db.UsersTeamPlayersTable)
                {
                    if (player.id == utp.playerId)
                    {
                        return "FullName : " + player.first_name + " " + player.second_name + "   Price :" +
                               player.now_cost +
                               "   Post :" +
                               player.element_type + "   Team :" + player.team + "   Role : ";

                    }
                }
            }
        }

        return null;
    }

    public static List<string> showListOfMyTeam(int userId)
    {
        string playerInfo = "";
        List<int> listOfSelectedPlayersIds = ListOfMyTeamPlayers.listOfUserTeamPlayerIds(userId);
        List<string> listOfplayersInfo = new List<string>();
        using (var db = new DataBase())
        {
            foreach (var player in db.playerTable)
            {
                foreach (var playerId in listOfSelectedPlayersIds)
                {
                    if (playerId == player.id)
                    {
                        listOfplayersInfo.Add("FullName : "+player.first_name + " " + player.second_name + "   Price :" + player.now_cost + "   Post :" +
                                              player.element_type + "   Team :" + player.team);
                    }
                }
            }

        }

        return listOfplayersInfo;
    }
    
    public static List<Player> selectedPlayersTeamList(int userId , Team targetTeam)
    {
        List<int> listOfPlIds = listOfUserTeamPlayerIds(userId);
        List<Player> TeamList = new List<Player>();
        using (var db = new DataBase())
        {
            foreach (var player in db.playerTable )
            {
                foreach (var id in listOfPlIds)
                {
                    if (player.id == id && targetTeam==player.team)
                    {
                        TeamList.Add(player);
                    }
                }
            }
        }

        return TeamList;
    }
    
    public static List<Player> selectedPlayersPostList(int userId , Post targetPost )
    {
        List<int> listOfPlIds =listOfUserTeamPlayerIds(userId);
        List<Player> postList = new List<Player>();
        using (var db = new DataBase())
        {
            foreach (var player in db.playerTable )
            {
                foreach (var id in listOfPlIds)
                {
                    if (player.id == id && player.element_type==targetPost)
                    {
                        postList.Add(player);
                    }
                }
            }
        }

        return postList;
    }
}