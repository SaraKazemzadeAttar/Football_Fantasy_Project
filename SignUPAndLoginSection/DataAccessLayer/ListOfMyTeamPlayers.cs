using NUnit.Framework;
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
                    if ( playerId==player.id &&player.id == utp.playerId)
                    {
                        return "FullName : " + player.first_name + " " + player.second_name + "   Price :" +
                               player.now_cost +
                               "   Post :" +
                               player.element_type + "   Team :" + player.team + "   Role : " +utp.roleOfPLayer;

                    }
                }
            }
        }

        return null;
    }

    public static List<string> showListOfMyTeam(int userId)
    {
        List<int> listOfSelectedPlayersIds =listOfUserTeamPlayerIds(userId);
        List<string> listOfplayersInfo = new List<string>();
        using (var db = new DataBase())
        {
            foreach (var player in db.playerTable)
            {
                foreach (var playerId in listOfSelectedPlayersIds)
                {
                    if (playerId == player.id)
                    {
                        string info = showInfoOfPlayer(player.id);
                        listOfplayersInfo.Add(info);
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
                    if (player.id == id)
                    {
                        if (targetTeam == player.team)
                        {
                            TeamList.Add(player);
                        }
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
            foreach (var player in db.playerTable)
            {
                foreach (var id in listOfPlIds)
                {
                    if (player.id == id)
                    {
                        if (player.element_type == targetPost)
                        {
                            postList.Add(player);
                        }
                    }
                }
            }
        }

        return postList;
    }
    
    public static List<UsersTeamPlayers> mySubstitutePlayersList(int userId)
    {
        List<UsersTeamPlayers> listOfSubstituesPlayers = new List<UsersTeamPlayers>();
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == userId)
                {
                    if (record.roleOfPLayer == RoleOfPlayer.SubstitutePlayer)
                    {
                        listOfSubstituesPlayers.Add(record);
                    }
                }
            }
        }

        return listOfSubstituesPlayers;
    }
    
    public static List<UsersTeamPlayers> myMainPlayersList(int userId)
    {
        List<UsersTeamPlayers> listOfMainPlayers = new List<UsersTeamPlayers>();
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == userId)
                {
                    if (record.roleOfPLayer == RoleOfPlayer.MainPlayer)
                    {
                        listOfMainPlayers.Add(record);
                    }
                }
            }
        }

        return listOfMainPlayers;
    }
    
}