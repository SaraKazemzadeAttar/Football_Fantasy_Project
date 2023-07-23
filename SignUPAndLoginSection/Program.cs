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
using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;
using ScoreBoard = SignUPAndLoginSection.presentationLayer.ScoreBoard;

namespace SignUPAndLoginSection
{
    public class program
    {
        [Obsolete("Obsolete")]
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
            
            builder.Services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionScopedJobFactory();
                var jobKey = new JobKey("DemoJob");
                q.AddJob<UpdateJob>(opts => opts.WithIdentity(jobKey));

                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("DemoJob-trigger")
                    .WithCronSchedule("0 0 7 * *"));

            });
            builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
            
            var app = builder.Build();
            app.UseCors("MyAllowedOrigins");
            app.MapPost("/signUp", presentationLayer.SignUp.signUPAPI);
            app.MapPost("/OTP", businessLayer.OTP.ValidatinOTPCode);
            app.MapPost("/login", presentationLayer.login.loginApi);
            app.MapGet("/ShowListOfPlayers", businessLayer.ListOfPlayers.getListOfPlayers);
            app.MapGet("/filterPlayersByAscendingPoint",businessLayer.ListOfPlayers.sortedAscendingListOfPlayersByPoint);
            app.MapGet("/filterPlayersByAscendingPrice",businessLayer.ListOfPlayers.sortedAscendingListOfPlayersByPrice);
            app.MapGet("/filterPlayersByDescendingPrice",businessLayer.ListOfPlayers.sortedDescendingListOfPlayersByPrice);
            app.MapGet("/filterPlayersByDescendingPoint",businessLayer.ListOfPlayers.sortedDescendingListOfPlayersByPoint);
            app.MapGet("/filterPlayersByPost",(int?post)=>businessLayer.ListOfPlayers.FilterPlayersByPost(post));
            app.MapGet("/filterPlayersByName", businessLayer.ListOfPlayers.searchingMethod);
            app.MapGet("/showScoresTable",presentationLayer.ScoreBoard.showScoresTableAPI);
            app.MapPost("/selectPlayer", presentationLayer.TeamPlayerSelection.selectionPlayerAPI);
            app.MapPost("/setSubstitutePlayer", presentationLayer.TeamPlayerSelection.setTheSubstitutePlayer);  
            app.MapGet("/showListOfMyTeam", presentationLayer.TeamPlayerSelection.showSelectedPlayersAPI);
            app.MapPost("/removePlayer", presentationLayer.TeamPlayerSelection.omittingPlayerAPI);
            app.MapGet("/displayCash", presentationLayer.Cash.displayUserCash);
            app.MapPost("/changeRoleOfPlayers", presentationLayer.TeamPlayerSelection.changeRoleOfPlayerAPI);
            app.MapGet("/userProfile", presentationLayer.profileOfUser.showUserProfile);
            app.MapGet("/ShowListOfPlayers", businessLayer.ListOfPlayers.getListOfPlayers);


            app.Run("http://localhost:7005");
            
        }
        

    }
    
}
