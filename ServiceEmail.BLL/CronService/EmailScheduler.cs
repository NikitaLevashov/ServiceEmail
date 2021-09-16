using Quartz;
using Quartz.Impl;
using ServiceEmail.BLL.TextService;
using System.Collections.Specialized;
using System.Linq;

namespace ServiceEmail.BLL.CronService
{
    public class EmailScheduler
    {
        public async void Start()
        {
            NameValueCollection properties = new NameValueCollection();
            properties["quartz.threadPool.threadCount"] = AppSettings.ThreadCount;

            ISchedulerFactory sf = new StdSchedulerFactory(properties);
            IScheduler scheduler = await sf.GetScheduler();

            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<EmailSender>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity($"{UserHelper.user.taskInfo.Last().MomentTaskStarts}", $"{UserHelper.user.taskInfo.Last().Name}")
                .StartAt(UserHelper.user.taskInfo.Last().MomentTaskStarts)
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(UserHelper.user.taskInfo.Last().PeriodicityTask)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
