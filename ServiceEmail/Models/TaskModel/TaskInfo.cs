using ServiceEmail.BLL.CronService;
using System;
using System.ComponentModel.DataAnnotations;


namespace ServiceEmail.UI.Models.TaskModel
{
    public class TaskInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Description { get; set; }

        [Required]
        public DateTime LastDateTime { get; set; }

        [Required]
        [Range(0,30)]
        public int PeriodicityTask { get; set; }

        [Required]
        public DateTime MomentTaskStarts { get; set; }

        [Required]
        public string FreeApi { get; set; }

        [Required]
        public string AppSettings { get; set; }
        public string DataOfTask { get; set; }
        public EmailScheduler EmailSheduler { get; set; }
    }
}
