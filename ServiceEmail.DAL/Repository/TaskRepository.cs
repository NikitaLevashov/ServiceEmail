using Microsoft.Data.Sqlite;
using ServiceEmail.DAL.Interfaces;
using ServiceEmail.DAL.Models.TaskInfoDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.DAL.Repository
{
    public class TaskRepository : ITaskRepository
    {
        public void Create(TaskInfoDAL task)
        {
            using (var connection = new SqliteConnection("Data Source=users.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;

                if (task != null)
                {
                    command.CommandText = $"INSERT INTO TasksInfo(Name, Description, LastDateTime, PeriodicityTask, MomentTaskStarts, FreeApi, AppSettings, DataOfTask, UserID)" +
                  $" VALUES('{task.Name}', '{task.Description}', '{task.LastDateTime}'," +
                  $"'{task.PeriodicityTask}','{task.MomentTaskStarts}','{task.FreeApi}','{task.AppSettings}'," +
                  $" '{task.DataOfTask}', '{task.UserId}')";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(TaskInfoDAL task)
        {
            using (var connection = new SqliteConnection("Data Source=users.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"DELETE FROM TasksInfo WHERE Id = '{task.Id}'";
                command.ExecuteNonQuery();

            }
        }
        public void Update(TaskInfoDAL task)
        {
            using (var connection = new SqliteConnection("Data Source=users.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"UPDATE TasksInfo SET Name = '{task.Name}', Description = '{task.Description}', LastDateTime = '{task.LastDateTime}'," +
                  $" PeriodicityTask = '{task.PeriodicityTask}', MomentTaskStarts = '{task.MomentTaskStarts}', FreeApi = '{task.FreeApi}', AppSettings = '{task.AppSettings}'," +
                  $" DataOfTask = '{task.DataOfTask}' WHERE Id = '{task.Id}'";
                command.ExecuteNonQuery();

            }
        }
    }
}
