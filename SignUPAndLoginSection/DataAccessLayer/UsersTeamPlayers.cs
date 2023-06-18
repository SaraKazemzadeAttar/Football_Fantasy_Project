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

}