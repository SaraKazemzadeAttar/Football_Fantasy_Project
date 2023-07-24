using SignUPAndLoginSection.businessLayer;

namespace SignUPAndLoginSection.presentationLayer;

public class Pagination
{
    public static List<Player> paginationFormOfListOfPlayers(int page, int limit)
    {
        List<Player> paginationList = new List<Player>();
        List<Player> players = ListOfPlayers.getListOfPlayers();
        for (int i = (page - 1) * limit; i < page * limit; i++)
        {
            paginationList.Add(players[i]);
        }

        return paginationList;
    }
}