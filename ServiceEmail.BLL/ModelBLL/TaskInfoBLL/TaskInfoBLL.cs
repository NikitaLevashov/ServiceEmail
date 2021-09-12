using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.BLL.ModelBLL.TaskInfoBLL
{
    public class TaskInfoBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastDateTime { get; set; }
        public int PeriodicityTask { get; set; }
        public DateTime MomentTaskStarts { get; set; }
        public string FreeApi { get; set; }
        public string AppSettings { get; set; }
        public string DataOfTask { get; set; }
    }
}
