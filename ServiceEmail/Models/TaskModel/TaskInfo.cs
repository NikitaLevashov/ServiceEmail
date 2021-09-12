using ServiceEmail.UI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceEmail.UI.Models.TaskModel
{
    public class TaskInfo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Description { get; set; }

        [Required]
        public DateTime LastDateTime { get; set; }

        [Required]
        [Range(0,24)]
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
