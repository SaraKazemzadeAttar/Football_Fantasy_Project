// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using ServiceStack;
// using SignUPAndLoginSection.presentationLayer;
// using SignUPAndLoginSection.DataAccessLayer;
// using SignUPAndLoginSection.businessLayer;
// using Ubiety.Dns.Core.Records;
// using User = SignUPAndLoginSection.businessLayer.User;
//
//
// namespace SignUPAndLoginSection.DataAccessLayer;
//
// public class UsersTeamPlayers
// {
//     [Key]
//     public int UsersTeamPlayersId { get; set; }
//
//     public int userId { get; set; }
//     
//     public int playerId { get; set; }
//
//
//     public static int numberOfPlayersFromThisTeam(int targetUserId,UsersTeamPlayers selectedPlayer)
//     {
//         int counterOfPlayersOfIntendedTeam = 0;
//         var intendedTeam = selectedPlayer.team;
//         using (var db = new DataBase())
//         {
//             foreach (var record in db.UsersTeamPlayersTable)
//             {
//                 if (record.userId == targetUserId)
//                 {
//                     foreach (var player in db.UsersTeamPlayersTable)
//                     {
//                         if (selectedPlayer.team == intendedTeam)
//                         {
//                             counterOfPlayersOfIntendedTeam++;
//                         }
//                     }
//                 }
//             }
//         }
//
//         return counterOfPlayersOfIntendedTeam;
//     }
//     
//
//     public static bool hasTeamUnderTwoGoalKeepers(int targetUserId)
//     {
//         using (var db = new DataBase())
//         {
//             foreach (var record in db.UsersTeamPlayersTable)
//             {
//                 if (record.userId == targetUserId)
//                 {
//                     foreach (var player in db.UsersTeamPlayersTable)
//                     {
//                         if (Convert.ToInt16(player.post) == 0)
//                         {
//                             counterOfGoalKeepers++;
//                         }
//                     }
//                 }
//             }
//         }
//
//         if (counterOfGoalKeepers < 2)
//         {
//             return true;
//         }
//
//         return false;
//     }
//
//     public static bool hasTeamUnderFiveDefenders(int targetUserId)
//     {
//         using (var db = new DataBase())
//         {
//             foreach (var record in db.UsersTeamPlayersTable)
//             {
//                 if (record.userId == targetUserId)
//                 {
//                     foreach (var player in db.UsersTeamPlayersTable)
//                     {
//                         var post = FootballPlayersData.findPLayerByTheirId(player.playerId).element_type;
//                         if (Convert.ToInt16(post) == 1)
//                         {
//                             counterOfDefenders++;
//                         }
//                     }
//                 }
//             }
//         }
//
//         if (counterOfDefenders < 5)
//         {
//             return true;
//         }
//
//         return false;
//     }
//
//     public static bool hasTeamUnderFiveMidfielders(int targetUserId)
//     {
//         using (var db = new DataBase())
//         {
//             foreach (var record in db.UsersTeamPlayersTable)
//             {
//                 if (record.userId == targetUserId)
//                 {
//                     foreach (var player in db.UsersTeamPlayersTable)
//                     {
//                         if (Convert.ToInt16(player.post) == 2)
//                         {
//                             counterOfMidfielders++;
//                         }
//                     }
//                 }
//             }
//         }
//
//         if (counterOfMidfielders < 5)
//         {
//             return true;
//         }
//
//         return false;
//     }
//
//     public static bool hasTeamUnderThreeForwards(int targetUserId)
//     {
//         using (var db = new DataBase())
//         {
//             foreach (var record in db.UsersTeamPlayersTable)
//             {
//                 if (record.userId == targetUserId)
//                 {
//                     foreach (var player in db.UsersTeamPlayersTable)
//                     {
//                         if (Convert.ToInt16(player.post) == 3)
//                         {
//                             counterOfForwards++;
//                         }
//                     }
//                 }
//             }
//         }
//
//         if (counterOfForwards < 3)
//         {
//             return true;
//         }
//
//         return false;
//     }
//     
//
//     public static void insertSelectedPlayerInUserTeam(int targetUserId , UsersTeamPlayers selectedPlayer)
//     {
//         using (var db = new DataBase())
//         {
//             foreach (var record in db.UsersTeamPlayersTable)
//             {
//                 if (record.userId == targetUserId)
//                 {
//                     db.UsersTeamPlayersTable.Add(selectedPlayer);
//                     db.SaveChanges();
//                 }
//             }
//         }
//     }
//
//     public static void RemovePlayer(int targetUserId,UsersTeamPlayers selectedplayer)
//     {
//         using (var db = new DataBase())
//         {
//             foreach (var record in db.UsersTeamPlayersTable )
//             {
//                 if (record.userId == targetUserId)
//                 {
//                     db.UsersTeamPlayersTable.Remove(selectedplayer);
//                     db.SaveChanges();
//                 }
//             }
//         }
//     }
//     public static void changingRoleOfPlayer(UsersTeamPlayers selectedPlayer)
//     {
//         using (var db = new DataBase())
//         {
//             switch (selectedPlayer.isMainPLayer)
//             {
//                 case true:
//                     selectedPlayer.isMainPLayer = false;
//                     db.SaveChanges();
//                     break;
//                 case false:
//                     selectedPlayer.isMainPLayer = true;
//                     db.SaveChanges();
//                     break;
//             }
//         }
//     }
// }