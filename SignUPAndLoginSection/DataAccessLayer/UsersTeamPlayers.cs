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
    
    
    public ICollection<Player> PlayersCollection  { get; set; }
    
    public ICollection<User> UsersCollection{get; set;}
    
    public bool isMainPLayer;
    public static string selectionPlayerErrorMessage = "";
    public static int counterOfGoalKeepers;
    public static int counterOfDefenders;
    public static int counterOfMidfielders;
    public static int counterOfForwards;

    public string firstName { get; set; }
    public double nowCost{ get; set; }
    public string secondName{ get; set; }
    public Player.Team team{ get; set; }
    public Player.Post post{ get; set; }
    public double totalPoints{ get; set; }
    public UsersTeamPlayers(Player player)
    {
        this.id = player.id;
        this.firstName = player.first_name;
        this.nowCost = player.now_cost;
        this.secondName = player.second_name;
        this.team = player.team;
        this.post = player.element_type;
        this.totalPoints = player.total_points;
    }
    

    public static int numberOfPlayersFromThisTeam(UsersTeamPlayers selectedPlayer)
    {
        int counterOfPlayersOfIntendedTeam = 0;
        var intendedTeam = selectedPlayer.team;
        using (var db = new DataBase())
        {
            foreach (var player in db.UsersTeamPlayersTable)
            {
                if (selectedPlayer.team == intendedTeam) 
                {
                    counterOfPlayersOfIntendedTeam++;
                }
            }
        }

        return counterOfPlayersOfIntendedTeam;
    }

    public static void insertSelectedPlayerInUserTeam(UsersTeamPlayers selectedPlayer)
    {
        using (var db = new DataBase())
        {
            db.UsersTeamPlayersTable.Add(selectedPlayer);
                db.SaveChanges();
        }
    }

    public static bool hasTeamUnderTwoGoalKeepers()
    {
        using (var db = new DataBase())
        {
            foreach (var player in db.UsersTeamPlayersTable)
            {
                if (Convert.ToInt16(player.post) == 0)
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
                if (Convert.ToInt16(player.post) == 2)
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
                if (Convert.ToInt16(player.post) == 3)
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

    public static void RemovePlayer(UsersTeamPlayers uPlayer, User u)
    {
        using (var db = new DataBase())
        {
            
            
        }

    }
}