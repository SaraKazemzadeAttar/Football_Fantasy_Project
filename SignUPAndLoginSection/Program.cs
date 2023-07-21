using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;
using System.Threading;
using CronNET;
using NCrontab;
using ServiceStack;
using ScoreBoard = SignUPAndLoginSection.presentationLayer.ScoreBoard;

namespace SignUPAndLoginSection
{
    public class program
    {
        public static void Main(string[] args)
        {
            FootballPlayersData.clearRecordsOfPlayerTable();
            FootballPlayersData.insertPlayersInDataBase();
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowedOrigins",
                    policy =>
                    {
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            var app = builder.Build();
            app.UseCors("MyAllowedOrigins");
            app.MapPost("/signUp", presentationLayer.SignUp.signUPAPI);
            app.MapPost("/OTP", businessLayer.OTP.ValidatinOTPCode);
            app.MapPost("/login", presentationLayer.login.loginApi);
            app.MapPost("/ShowListOfPlayers", businessLayer.ListOfPlayers.getListOfPlayers);
            app.MapPost("/filterPlayersByAscendingPoint",businessLayer.ListOfPlayers.sortedAscendingListOfPlayersByPoint);
            app.MapPost("/filterPlayersByAscendingPrice",businessLayer.ListOfPlayers.sortedAscendingListOfPlayersByPrice);
            app.MapPost("/filterPlayersByDescendingPrice",businessLayer.ListOfPlayers.sortedDescendingListOfPlayersByPrice);
            app.MapPost("/filterPlayersByDescendingPoint",businessLayer.ListOfPlayers.sortedDescendingListOfPlayersByPoint);
            app.MapPost("/filterPlayersByPost",(int?post)=>businessLayer.ListOfPlayers.FilterPlayersByPost(post));
            app.MapPost("/filterPlayersByName", businessLayer.ListOfPlayers.searchingMethod);
            app.MapGet("/showScoresTable",presentationLayer.ScoreBoard.showScoresTableWeeklyAPI);
            app.MapPost("/selectPlayer", presentationLayer.TeamPlayerSelection.selectionPlayerAPI);
            app.MapPost("/setSubstitutePlayer", presentationLayer.TeamPlayerSelection.setTheSubstitutePlayer);  
            app.MapGet("/showListOfMyTeam", presentationLayer.TeamPlayerSelection.showSelectedPlayersAPI);
            app.MapPost("/removePlayer", presentationLayer.TeamPlayerSelection.omittingPlayerAPI);
            app.MapGet("/displayCash", presentationLayer.Cash.displayUserCash);
            app.MapPost("/changeRoleOfPlayers", presentationLayer.TeamPlayerSelection.changeRoleOfPlayerAPI);
            app.MapGet("/userProfile", presentationLayer.profileOfUser.showUserProfile);
            app.MapPost("/ShowListOfPlayers",updateListOfPlayers);
            app.MapPost("/ShowListOfPlayers", businessLayer.ListOfPlayers.getListOfPlayers);


            app.Run("http://localhost:7005");
            
        }
        
        public static void updateListOfPlayers()
        {
            DateTime now = DateTime.Now;
            DateTime nextRun = CalculateNextWeeklyRun(now);
            TimeSpan delay = nextRun - now;
            var timer = new System.Threading.Timer(_ =>
            {
                FootballPlayersData.clearRecordsOfPlayerTable();
                FootballPlayersData.insertPlayersInDataBase(); // Call the function to insert players in the database
            }, null, delay, TimeSpan.FromDays(7));
            
            while (true)
            {
                Thread.Sleep(Timeout.Infinite);
            }
        }
        
        public static void showScoresTableWeeklyAPI()
        {
            DateTime now = DateTime.Now;
            DateTime nextRun = CalculateNextWeeklyRun(now);
            TimeSpan duration = nextRun - now;

            var timer = new Timer(o => {ScoreBoard.showScoresTableAPI();}, null, TimeSpan.Zero, duration);
            //t.Change(0,100);
        }
        
        public static DateTime CalculateNextWeeklyRun(DateTime now)
        {
            // Get the current day of the week
            int currentDayOfWeek = (int)now.DayOfWeek;
            // Calculate the number of days until the next Sunday (day of the week: 0)
            int daysUntilNextSunday = (7 - currentDayOfWeek) % 7;
            // Calculate the next weekly run by adding the days to the current date
            DateTime nextRun = now.AddDays(daysUntilNextSunday);
            // Set the time to midnight (0:00) for consistency
            nextRun = nextRun.Date;
        
            return nextRun;
        }
    }
}
