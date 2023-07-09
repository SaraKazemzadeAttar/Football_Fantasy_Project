using System;
using System.Net;
using System.Net.Mail;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.DataAccessLayer;
using SignUPAndLoginSection.presentationLayer;
using System.Threading;
using CronNET;
using NCrontab;

namespace SignUPAndLoginSection
{
    public class program
    {
        public static void Main(string[] args)
        {
            DataAccessLayer.FootballPlayersData.insertPlayersInDataBase();

            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.MapPost("/login", presentationLayer.login.loginApi);
            app.MapPost("/signUp", presentationLayer.SignUp.signUPAPI);
            app.MapPost("/otp", businessLayer.OTP
                .ValidatinOTPCode);
            app.MapPost("/ListOfPlayers",(int? filter)=>businessLayer.ListOfPlayers.FilterPlayers(filter));
            app.MapPost("/ListOfPlayersPost",(int?post)=>businessLayer.ListOfPlayers.FilterPlayersByPost(post));
            app.MapPost("/ListOfPlayersName", businessLayer.ListOfPlayers.searchingMethod);
            app.MapPost("/TableScore",DataAccessLayer.ScoreTable.usersTable);
            app.MapPost("/selectPlayer", presentationLayer.TeamPlayerSelection.selectionPlayerAPI);
            app.MapPost("/RemovePlayer", presentationLayer.TeamPlayerSelection.omittingPlayerAPI);
            app.MapGet("/ChangeRoleOfPlayer", presentationLayer.TeamPlayerSelection.changeRoleOfPlayerAPI);



            app.Run("http://localhost:3001");

            // Calculate the delay until the next weekly occurrence
            DateTime now = DateTime.Now;
            DateTime nextRun = CalculateNextWeeklyRun(now);
            TimeSpan delay = nextRun - now;

            // Create a timer to execute the task when the next occurrence is due
            var timer = new System.Threading.Timer(_ =>
            {
                FootballPlayersData.insertPlayersInDataBase(); // Call the function to insert players in the database
            }, null, delay, TimeSpan.FromDays(7)); // Set the timer interval to 7 days (weekly)

            // Wait and sleep forever. Let the cron job run.
            while (true)
            {
                Thread.Sleep(Timeout.Infinite);
            }
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
