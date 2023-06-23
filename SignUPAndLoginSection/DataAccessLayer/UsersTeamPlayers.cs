using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
using Ubiety.Dns.Core.Records;
using User = SignUPAndLoginSection.businessLayer.User;


namespace SignUPAndLoginSection.DataAccessLayer;

public class UsersTeamPlayers
{
    [Key]
    public int UsersTeamPlayersId { get; set; }
    
    [Display(Name = "userTable")]
    public static int userId { get; set; }

    [ForeignKey("userId")]
    public User userTable { get; set; }
    
    [Display(Name = "playerTable")]
    public int id { get; set; }

    [ForeignKey("id")]
    public Player playerTable { get; set; }
    
    public   ICollection<Player> PlayersCollection  { get; set; }
    
    public ICollection<User> UsersCollectiom{get; set;}
    
    public bool isMainPLayer;
    public static string selectionPlayerErrorMessage = "";
    public static int counterOfGoalKeepers;
    public static int counterOfDefenders;
    public static int counterOfMidfielders;
    public static int counterOfForwards;

    public static void insertSelectedPlayerInUserTeam(Player player)
    {

        using (var db = new DataBase())
        {
            Player selectedPlayer = new Player() { id= player.id};
            db.playerTable.Attach(selectedPlayer);

            UsersTeamPlayers selectedPlayerInsertingMyTeam = db.UsersTeamPlayersTable.SingleOrDefault();
            selectedPlayerInsertingMyTeam = new UsersTeamPlayers();
            db.UsersTeamPlayersTable.Add(selectedPlayerInsertingMyTeam);
            db.SaveChanges();
        }
    }
    
    public static int numberOfPlayersFromThisTeam(Player selectedPlayer)
    {
        int counterOfPlayersOfIntendedTeam = 0;
        var intendedTeam = selectedPlayer.team;
        using (var db = new DataBase())
        {
            foreach (var player in db.UsersTeamPlayersTable)
            {
                if (selectedPlayer.team == intendedTeam) // should be player.team; but this class doesn't have team field!
                {
                    counterOfPlayersOfIntendedTeam++;
                }
            }
        }

        return counterOfPlayersOfIntendedTeam;
    }

    public static bool hasTeamUnderTwoGoalKeepers()
    {
        using (var db = new DataBase())
        {
            foreach (var player in db.UsersTeamPlayersTable)
            {
                var post = FootballPlayersData.findPLayerByTheirId(player.id).element_type;
                if (Convert.ToInt16(post) == 0)
                {
                    counterOfGoalKeepers++;
                }
            }
        }

        if (counterOfGoalKeepers < 2)
        {
            return true;
        }

        return false;
    }

    public static bool hasTeamUnderFiveDefenders()
    {
        using (var db = new DataBase())
        {
            foreach (var player in db.UsersTeamPlayersTable)
            {
                var post = FootballPlayersData.findPLayerByTheirId(player.id).element_type;
                if (Convert.ToInt16(post) == 1)
                {
                    counterOfDefenders++;
                }
            }
        }

        if (counterOfDefenders < 5)
        {
            return true;
        }

        return false;
    }

    public static bool hasTeamUnderFiveMidfielders()
    {
        using (var db = new DataBase())
        {
            foreach (var player in db.UsersTeamPlayersTable)
            {
                var post = FootballPlayersData.findPLayerByTheirId(player.id).element_type;
                if (Convert.ToInt16(post) == 2)
                {
                    counterOfMidfielders++;
                }
            }
        }

        if (counterOfMidfielders < 5)
        {
            return true;
        }

        return false;
    }

    public static bool hasTeamUnderThreeForwards()
    {
        using (var db = new DataBase())
        {
            foreach (var player in db.UsersTeamPlayersTable)
            {
                var post = FootballPlayersData.findPLayerByTheirId(player.id).element_type;
                if (Convert.ToInt16(post) == 3)
                {
                    counterOfForwards++;
                }
            }
        }

        if (counterOfForwards < 3)
        {
            return true;
        }

        return false;
    }

    public static void changingRoleOfPlayer(UsersTeamPlayers uPlayer)
    {
        using (var db = new DataBase())
        {
            switch (uPlayer.isMainPLayer)
            {
                case true:
                    uPlayer.isMainPLayer = false;
                    db.SaveChanges();
                    break;
                case false:
                    uPlayer.isMainPLayer = true;
                    db.SaveChanges();
                    break;
            }
        }
    }
}