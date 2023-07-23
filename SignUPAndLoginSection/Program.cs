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
                    .WithCronSchedule("0 0 12 ? * WED"));
            
            });
            builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
            
            var app = builder.Build();
            app.UseCors("MyAllowedOrigins");
            app.MapPost("/signUp",SignUp.signUPAPI);
            app.MapPost("/OTP", OTP.ValidatinOTPCode);
            app.MapGet("/login", presentationLayer.login.loginApi);
            app.MapGet("/filterPlayersByAscendingPoint",ListOfPlayers.sortedAscendingListOfPlayersByPoint);
            app.MapGet("/filterPlayersByAscendingPrice",ListOfPlayers.sortedAscendingListOfPlayersByPrice);
            app.MapGet("/filterPlayersByDescendingPrice",ListOfPlayers.sortedDescendingListOfPlayersByPrice);
            app.MapGet("/filterPlayersByDescendingPoint",ListOfPlayers.sortedDescendingListOfPlayersByPoint);
            app.MapGet("/filterPlayersByPost",(int?post)=>ListOfPlayers.FilterPlayersByPost(post));
            app.MapGet("/filterPlayersByName", ListOfPlayers.searchingMethod);
            app.MapGet("/showScoresTable",ScoreBoard.showScoresTableAPI);
            app.MapPost("/selectPlayer", TeamPlayerSelection.selectionPlayerAPI);
            app.MapPost("/setSubstitutePlayer", TeamPlayerSelection.setTheSubstitutePlayer);  
            app.MapGet("/showListOfMyTeam", TeamPlayerSelection.showSelectedPlayersAPI);
            app.MapGet("/showListOfMyMainPlayers",ListOfMyTeam.ListOfMainPlayers);
            app.MapGet("/showListOfMySubstitutePlayers",ListOfMyTeam.ListOfSubstitutePlayers);
            app.MapPost("/removePlayer", TeamPlayerSelection.omittingPlayerAPI);
            app.MapGet("/displayCash", presentationLayer.Cash.displayUserCash);
            app.MapPost("/changeRoleOfPlayers", TeamPlayerSelection.changeRoleOfPlayerAPI);
            app.MapGet("/userProfile", profileOfUser.showUserProfile);
            app.MapGet("/ShowListOfPlayers", ListOfPlayers.getListOfPlayers);


            app.Run("http://localhost:7005");
            
        }
        

    }
    
}
