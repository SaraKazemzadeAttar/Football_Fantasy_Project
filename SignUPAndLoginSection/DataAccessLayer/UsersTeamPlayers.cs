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
    public int userId { get; set; }

    [ForeignKey("userId")]
    public User userTable { get; set; }
    
    [Display(Name = "playerTable")]
    public int id { get; set; }

    [ForeignKey("id")]
    public Player playerTable { get; set; }
    
    
    public ICollection<Player> PlayersCollection  { get; set; }
    
    public ICollection<User> UsersCollection{get; set;}
    
    public bool isMainPLayer =false ;
    public bool hasPlayerSelectionConditions = false;
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
    public UsersTeamPlayers(Player player )
    {
        this.id = player.id;
        this.firstName = player.first_name;
        this.nowCost = player.now_cost;
        this.secondName = player.second_name;
        this.team = player.team;
        this.post = player.element_type;
        this.totalPoints = player.total_points;
    }
    

    public static int numberOfPlayersFromThisTeam(int targetUserId,UsersTeamPlayers selectedPlayer)
    {
        int counterOfPlayersOfIntendedTeam = 0;
        var intendedTeam = selectedPlayer.team;
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    foreach (var player in db.UsersTeamPlayersTable)
                    {
                        if (selectedPlayer.team == intendedTeam)
                        {
                            counterOfPlayersOfIntendedTeam++;
                        }
                    }
                }
            }
        }

        return counterOfPlayersOfIntendedTeam;
    }
    

    public static bool hasTeamUnderTwoGoalKeepers(int targetUserId)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    foreach (var player in db.UsersTeamPlayersTable)
                    {
                        if (Convert.ToInt16(player.post) == 0)
                        {
                            counterOfGoalKeepers++;
                        }
                    }
                }
            }
        }

        if (counterOfGoalKeepers < 2)
        {
            return true;
        }

        return false;
    }

    public static bool hasTeamUnderFiveDefenders(int targetUserId)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
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
            }
        }

        if (counterOfDefenders < 5)
        {
            return true;
        }

        return false;
    }

    public static bool hasTeamUnderFiveMidfielders(int targetUserId)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    foreach (var player in db.UsersTeamPlayersTable)
                    {
                        if (Convert.ToInt16(player.post) == 2)
                        {
                            counterOfMidfielders++;
                        }
                    }
                }
            }
        }

        if (counterOfMidfielders < 5)
        {
            return true;
        }

        return false;
    }

    public static bool hasTeamUnderThreeForwards(int targetUserId)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    foreach (var player in db.UsersTeamPlayersTable)
                    {
                        if (Convert.ToInt16(player.post) == 3)
                        {
                            counterOfForwards++;
                        }
                    }
                }
            }
        }

        if (counterOfForwards < 3)
        {
            return true;
        }

        return false;
    }
    

    public static void insertSelectedPlayerInUserTeam(int targetUserId , UsersTeamPlayers selectedPlayer)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable)
            {
                if (record.userId == targetUserId)
                {
                    db.UsersTeamPlayersTable.Add(selectedPlayer);
                    db.SaveChanges();
                }
            }
        }
    }

    public static void RemovePlayer(int targetUserId,UsersTeamPlayers selectedplayer)
    {
        using (var db = new DataBase())
        {
            foreach (var record in db.UsersTeamPlayersTable )
            {
                if (record.userId == targetUserId)
                {
                    db.UsersTeamPlayersTable.Remove(selectedplayer);
                    db.SaveChanges();
                }
            }
        }
    }
    public static void changingRoleOfPlayer(UsersTeamPlayers selectedPlayer)
    {
        using (var db = new DataBase())
        {
            switch (selectedPlayer.isMainPLayer)
            {
                case true:
                    selectedPlayer.isMainPLayer = false;
                    db.SaveChanges();
                    break;
                case false:
                    selectedPlayer.isMainPLayer = true;
                    db.SaveChanges();
                    break;
            }
        }
    }
}