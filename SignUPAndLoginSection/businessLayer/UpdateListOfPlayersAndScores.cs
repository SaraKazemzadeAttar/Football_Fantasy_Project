// namespace SignUPAndLoginSection.businessLayer;
//
// using Quartz;
// using Quartz.Impl;
// using System;
// using System.Threading.Tasks;
//
// public class UpdateJob : IJob
// {
//     public Task Execute(IJobExecutionContext context)
//     {
//         
//         return Task.CompletedTask;
//     }
// }
//
// public class Scheduler
// {
//     public Task Start()
//     {
//         ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
//         IScheduler scheduler = schedulerFactory.GetScheduler();
//         scheduler.Start();
//         
//         IJobDetail job = JobBuilder.Create<UpdateJob>().Build();
//         ITrigger trigger = TriggerBuilder.Create()
//             .WithSchedule(CronScheduleBuilder.WeeklyOnDayAndHourAndMinute(DayOfWeek.Monday, 0, 0))
//             .Build();
//         
//         scheduler.ScheduleJob(job, trigger);
//     }
// }
// }