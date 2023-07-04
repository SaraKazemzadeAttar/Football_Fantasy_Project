// using System;
// using SignUPAndLoginSection.DataAccessLayer;
// using SignUPAndLoginSection.presentationLayer;
//
// namespace SignUPAndLoginSection.businessLayer;
//
// public class TeamPlayersSelection
// {
//     public static void changeRoleOfPlayer(string token ,UsersTeamPlayers selectedPlayer)
//     {
//         UsersTeamPlayers.changingRoleOfPlayer(selectedPlayer);
//     }
//
//     public static void omitPlayer(string token ,UsersTeamPlayers selectedPlayer) 
//     {
//         var user = UsersData.FindUserByTheirToken(token);
//         int targetUserId = user.userId;
//         UsersTeamPlayers.RemovePlayer(targetUserId,selectedPlayer);
//     }
//
//     public static bool isSelectionSuccessful(string token, UsersTeamPlayers selectedPlayer)
//     {
//         var user = UsersData.FindUserByTheirToken(token);
//         int targetUserId = user.userId;  // I doubt so much... !!!???
//         bool MoneyCondition = hasUserEnoughMoney(user, selectedPlayer);
//         bool ArrangeCondition = AreSelectedPlayerInCorrectArrange( targetUserId ,selectedPlayer);
//         bool TeamCondition = AreUnderFourPlayersFromOneTeam(targetUserId ,selectedPlayer);
//
//         if (MoneyCondition && ArrangeCondition && TeamCondition)
//         {
//             selectedPlayer.hasPlayerSelectionConditions = true;
//             playerSelection(targetUserId,selectedPlayer);
//             return true;
//         }
//         else
//         {
//             selectedPlayer.hasPlayerSelectionConditions = false;
//             return false;
//         }
//     }
//     public static bool AreSelectedPlayerInCorrectArrange(int targetUserId , UsersTeamPlayers selectedPlayer)
//     {
//         var intendedPost = selectedPlayer.post;
//         switch (intendedPost)
//         {
//             case Player.Post.Goalkeeper:
//                 return UsersTeamPlayers.hasTeamUnderTwoGoalKeepers(targetUserId);
//             case Player.Post.Defender:
//                 return UsersTeamPlayers.hasTeamUnderFiveDefenders(targetUserId);
//             case Player.Post.Midfielder:
//                 return UsersTeamPlayers.hasTeamUnderFiveMidfielders(targetUserId);
//             case Player.Post.Forward:
//                 return UsersTeamPlayers.hasTeamUnderThreeForwards(targetUserId);
//             default:
//                 return false;
//         }
//     }
//
//     public static bool hasUserEnoughMoney(presentationLayer.User user, UsersTeamPlayers selctedPlayer)
//     {
//         if (user.cash < selctedPlayer.nowCost)
//         {
//             UsersTeamPlayers.selectionPlayerErrorMessage = "You have not enough money to buy this player!";
//             return false;
//         }
//
//         return true;
//     }
//
//     public static bool AreUnderFourPlayersFromOneTeam(int targetUserId,UsersTeamPlayers selectedPlayer)
//     {
//         if (UsersTeamPlayers.numberOfPlayersFromThisTeam(targetUserId ,selectedPlayer) > 4)
//         {
//             UsersTeamPlayers.selectionPlayerErrorMessage = "You have selected three players from this team before!";
//             return false;
//         }
//
//         return true;
//     }
//
//     public static void playerSelection (int targetUserId,UsersTeamPlayers selectedPlayer)
//     {
//         UsersTeamPlayers.insertSelectedPlayerInUserTeam(targetUserId,selectedPlayer);
//     }
//     
// }