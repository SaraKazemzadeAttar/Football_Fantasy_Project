using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
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
     public  int id{ get; set; }

     [ForeignKey("id")] 
     public Player playerTable { get; set; }
     
     
     //--------------------------------------------------------------- other fields

     public bool isMainPLayer;
     public static string selectionPlayerErrorMessage = "";

     public static void insertSelectedPlayerInUserTeam(Player player)
     {
          using (var db = new DataBase())
          {
               db.playerTable.Add(player);
               db.SaveChanges();
          }
     }
     
     
     public static int numberOfPlayersFromThisTeam(Player selectedPlayer)
     {
          var counterPlayersOfIntendedTeam = 0;
          var intendedTeam = selectedPlayer.team;
          using (var db = new DataBase())
          {
               foreach ( var player in db.UsersTeamPlayersTable)
               {
                    if (selectedPlayer.team == intendedTeam) 
                         counterPlayersOfIntendedTeam++;
               }
          }

          return counterPlayersOfIntendedTeam;
     }
}