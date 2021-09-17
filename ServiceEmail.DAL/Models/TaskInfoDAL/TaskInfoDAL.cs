namespace ServiceEmail.DAL.Models.TaskInfoDAL
{
    public class TaskInfoDAL
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LastDateTime { get; set; }
        public int PeriodicityTask { get; set; }
        public string MomentTaskStarts { get; set; }
        public string FreeApi { get; set; }
        public string AppSettings { get; set; }
        public string DataOfTask { get; set; }
        public int UserId { get; set; }        
    }
}
