using SignUPAndLoginSection.DataAccessLayer;
using ScoreBoard = SignUPAndLoginSection.presentationLayer.ScoreBoard;

namespace SignUPAndLoginSection.businessLayer;

using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

public class UpdateJob : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        ScoreBoard.showScoresTableAPI();
        FootballPlayersData.clearRecordsOfPlayerTable();
        FootballPlayersData.insertPlayersInDataBase();
        return Task.FromResult(true);
    }
}