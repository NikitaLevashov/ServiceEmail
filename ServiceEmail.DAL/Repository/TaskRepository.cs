using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using ServiceEmail.DAL.Interfaces;
using ServiceEmail.DAL.Models.TaskInfoDAL;


namespace ServiceEmail.DAL.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration Configuration;
        public TaskRepository(IConfiguration config)
        {
            Configuration = config;
        }
        public void Create(TaskInfoDAL task)
        {
            using (var connection = new SqliteConnection(Configuration["Data:UserDataBase:ConnectionStrings"]))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.Parameters.AddWithValue("@name", task.Name);
                command.Parameters.AddWithValue("@description", task.Description);
                command.Parameters.AddWithValue("@lastdatetime", task.LastDateTime);
                command.Parameters.AddWithValue("@period", task.PeriodicityTask);
                command.Parameters.AddWithValue("@moment", task.MomentTaskStarts);
                command.Parameters.AddWithValue("@freeapi", task.FreeApi);
                command.Parameters.AddWithValue("@tasksetting", task.AppSettings);
                command.Parameters.AddWithValue("@data", task.DataOfTask);
                command.Parameters.AddWithValue("@userid", task.UserId);

                if (task != null)
                {
                    command.CommandText = $"INSERT INTO TasksInfo(Name, Description, LastDateTime, PeriodicityTask, MomentTaskStarts, FreeApi, AppSettings, DataOfTask, UserID)" +
                  $" VALUES(@name, @description, @lastdatetime," +
                  $"@period, @moment, @freeapi, @tasksetting," +
                  $" @data, @userid)";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(TaskInfoDAL task)
        {
            using (var connection = new SqliteConnection(Configuration["Data:UserDataBase:ConnectionStrings"]))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.Parameters.AddWithValue("@id", task.Id);
                command.CommandText = $"DELETE FROM TasksInfo WHERE Id = @id";
                command.ExecuteNonQuery();

            }
        }
        public void Update(TaskInfoDAL task)
        {
            using (var connection = new SqliteConnection(Configuration["Data:UserDataBase:ConnectionStrings"]))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.Parameters.AddWithValue("@name", task.Name);
                command.Parameters.AddWithValue("@description", task.Description);
                command.Parameters.AddWithValue("@lastdatetime", task.LastDateTime);
                command.Parameters.AddWithValue("@period", task.PeriodicityTask);
                command.Parameters.AddWithValue("@moment", task.MomentTaskStarts);
                command.Parameters.AddWithValue("@freeapi", task.FreeApi);
                command.Parameters.AddWithValue("@tasksetting", task.AppSettings);
                command.Parameters.AddWithValue("@data", task.DataOfTask);
                command.Parameters.AddWithValue("@taskid", task.Id);

                command.CommandText = $"UPDATE TasksInfo SET Name = @name, Description = @description, LastDateTime = @lastdatetime," +
                  $" PeriodicityTask = @period, MomentTaskStarts = @moment, FreeApi = @freeapi, AppSettings = @tasksetting," +
                  $" DataOfTask = @data WHERE Id = @taskid";
                command.ExecuteNonQuery();

            }
        }
    }
}
