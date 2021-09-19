using Quartz;
using Quartz.Impl;
using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using ServiceEmail.BLL.TextService;
using System.Collections.Specialized;
using System.Linq;

namespace ServiceEmail.BLL.CronService
{
    public class EmailScheduler
    {
        public async void Start(TaskInfoBLL task)
        {
            NameValueCollection properties = new NameValueCollection();
            properties["quartz.threadPool.threadCount"] = AppSettings.ThreadCount;

            ISchedulerFactory sf = new StdSchedulerFactory(properties);
            IScheduler scheduler = await sf.GetScheduler();

            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<EmailSender>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity($"{task.MomentTaskStarts}", $"{task.Name}")
                .StartAt(task.MomentTaskStarts)
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(task.PeriodicityTask) 
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        public async void Stop(TaskInfoBLL task)
        {
            NameValueCollection properties = new NameValueCollection();

            ISchedulerFactory sf = new StdSchedulerFactory(properties);
            IScheduler sched = await sf.GetScheduler();
            await sched.DeleteJob(new JobKey($"{task.MomentTaskStarts}",
                $"{ task.Name}"));
        }
    }
}
