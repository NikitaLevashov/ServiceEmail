//using Quartz;
//using Quartz.Impl;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ServiceEmail.BLL.CronService
//{
//    public class EmailScheduler
//    {
//        public static async void Start()
//        {
//            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
//            await scheduler.Start();

//            IJobDetail job = JobBuilder.Create<EmailSender>().Build();

//            ITrigger trigger = TriggerBuilder.Create()  // создаем триггер
//                .WithIdentity("trigger1", "group1")     // идентифицируем триггер с именем и группой
//                .StartAt(new DateTime(2, 12, 12)).StartNow()                            // запуск сразу после начала выполнения
//                .WithSimpleSchedule(x => x            // настраиваем выполнение действия
//                    .WithIntervalInSeconds(10)          // через 1 минуту
//                    .RepeatForever())                   // бесконечное повторение
//                .Build();                               // создаем триггер

//            await scheduler.ScheduleJob(job, trigger);        // начинаем выполнение работы
//        }
//    }
//}
