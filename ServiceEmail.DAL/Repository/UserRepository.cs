using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using ServiceEmail.DAL.Interfaces;
using ServiceEmail.DAL.Models.TaskInfoDAL;
using ServiceEmail.DAL.Models.UserDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration Configuration;
        public UserRepository(IConfiguration config)
        {
            Configuration = config;
        }
        public IEnumerable<UserDL> GetAll()
        {
            string sqlExpression = @"
                         SELECT   Users.Id, Users.Name, Users.Lastname, Users.Email, Users.Password, TasksInfo.Id, TasksInfo.Name, TasksInfo.Description, TasksInfo.FreeApi,
		           TasksInfo.PeriodicityTask, TasksInfo.MomentTaskStarts, TasksInfo.DataOfTask,
                   TasksInfo.AppSettings, TasksInfo.LastDateTime, Roles.Id, Roles.Name
                   FROM Users
                   LEFT JOIN TasksInfo on Users.Id = TasksInfo.UserId
		           LEFT JOIN Roles on Users.RoleId = Roles.Id";

            using (var connection = new SqliteConnection(Configuration["Data:UserDataBase:ConnectionStrings"]))
            {
                connection.Open();
                List<UserDL> users = new List<UserDL>();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int taskId;
                            string taskName;
                            string taskDescription;
                            string taskFreeApi;
                            int taskPeriodcityTask;
                            string taskMomentTaskStarts;
                            string taskDataOfTask;
                            string taskAppSettings;
                            string taskLastDateTime;
                            int roleId;
                            string roleName;
                            var userId = reader.GetInt32(0);
                            var userName = reader.GetString(1);
                            var usesLastName = reader.GetString(2);
                            var userEmail = reader.GetString(3);
                            var userPassword = reader.GetString(4);

                            taskId = reader.IsDBNull(5) ? taskId = 0
                              : taskId = reader.GetInt32(5);
                            taskName = reader.IsDBNull(6) ? taskName = null
                                : taskName = reader.GetString(6);
                            taskDescription = reader.IsDBNull(7) ? taskDescription = null
                                : taskDescription = reader.GetString(7);
                            taskFreeApi = reader.IsDBNull(8) ? taskFreeApi = null
                                : taskFreeApi = reader.GetString(8);
                            taskPeriodcityTask = reader.IsDBNull(9) ? taskPeriodcityTask = 0
                                : taskPeriodcityTask = reader.GetInt32(9);
                            taskMomentTaskStarts = reader.IsDBNull(10) ? taskMomentTaskStarts = null
                                : taskMomentTaskStarts = reader.GetString(10);
                            taskDataOfTask = reader.IsDBNull(11) ? taskDataOfTask = null
                                : taskDataOfTask = reader.GetString(11);
                            taskAppSettings = reader.IsDBNull(12) ? taskAppSettings = null
                                : taskAppSettings = reader.GetString(12);
                            taskLastDateTime = reader.IsDBNull(13) ? taskLastDateTime = null
                                : taskLastDateTime = reader.GetString(13);
                            roleId = reader.IsDBNull(14) ? roleId = 0
                                : reader.GetInt32(14);
                            roleName = reader.IsDBNull(15) ? roleName = null
                                : roleName = reader.GetString(15);

                            var user = users.Where(p => p.Id == userId).FirstOrDefault();
                            if (user == null)
                            {
                                user = new UserDL();
                                user.Id = userId;
                                user.Name = userName;
                                user.LastName = usesLastName;
                                user.Email = userEmail;
                                user.Password = userPassword;
                                user.Role = new RoleDL
                                {
                                    Id = roleId,
                                    Name = roleName
                                };

                                var task = new TaskInfoDAL()
                                {
                                    Id = taskId,
                                    Name = taskName,
                                    Description = taskDescription,
                                    FreeApi = taskFreeApi,
                                    PeriodicityTask = taskPeriodcityTask,
                                    AppSettings = taskAppSettings,
                                    DataOfTask = taskDataOfTask,
                                    LastDateTime = taskLastDateTime,
                                    MomentTaskStarts = taskMomentTaskStarts,
                                };

                                user.TaskInfo = new List<TaskInfoDAL>();
                                user.TaskInfo.Add(task);
                                users.Add(user);
                            }
                            else
                            {
                                var task = new TaskInfoDAL()
                                {
                                    Id = taskId,
                                    Name = taskName,
                                    Description = taskDescription,
                                    FreeApi = taskFreeApi,
                                    PeriodicityTask = taskPeriodcityTask,
                                    AppSettings = taskAppSettings,
                                    DataOfTask = taskDataOfTask,
                                    LastDateTime = taskLastDateTime,
                                    MomentTaskStarts = taskMomentTaskStarts,
                                };

                                if (!user.TaskInfo.Contains(task))
                                    user.TaskInfo.Add(task);
                            }
                        }
                    }
                    return users;
                }
            }
        }
        public void Create(UserDL user)
        {
            using (var connection = new SqliteConnection(Configuration["Data:UserDataBase:ConnectionStrings"]))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;

                if (user != null)
                {
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@name", user.Name);
                    command.Parameters.AddWithValue("@lastname", user.LastName);
                    command.Parameters.AddWithValue("@role", user.Role.Id);
                    command.CommandText = $"INSERT INTO Users(Name, LastName, Password, Email, RoleId)" +
                          $" VALUES(@name, @lastname, @password, @email, @role)";
                    command.ExecuteNonQuery();
                }
            }
        }

        public UserDL GetUser(UserDL userDAL)
        {
            using (var connection = new SqliteConnection(Configuration["Data:UserDataBase:ConnectionStrings"]))
            {
                connection.Open();
                List<UserDL> users = new List<UserDL>();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.Parameters.AddWithValue("@password", userDAL.Password);
                command.Parameters.AddWithValue("@email", userDAL.Email);

                command.CommandText = $"SELECT Users.Id, Users.Name, Users.Lastname, Users.Email, Users.Password," +
                $" TasksInfo.Id, TasksInfo.Name, TasksInfo.Description, TasksInfo.FreeApi, TasksInfo.PeriodicityTask," +
                $" TasksInfo.MomentTaskStarts, TasksInfo.DataOfTask, TasksInfo.AppSettings, TasksInfo.LastDateTime," +
                $" Roles.Id, Roles.Name FROM Users LEFT JOIN TasksInfo on Users.Id = TasksInfo.UserId" +
                $" LEFT JOIN Roles on Users.RoleId = Roles.Id WHERE Users.Email = @email AND Users.Password = @password";
                command.ExecuteNonQuery();

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int taskId;
                            string taskName;
                            string taskDescription;
                            string taskFreeApi;
                            int taskPeriodcityTask;
                            string taskMomentTaskStarts;
                            string taskDataOfTask;
                            string taskAppSettings;
                            string taskLastDateTime;
                            int roleId;
                            string roleName;
                            var userId = reader.GetInt32(0);
                            var userName = reader.GetString(1);
                            var usesLastName = reader.GetString(2);
                            var userEmail = reader.GetString(3);
                            var userPassword = reader.GetString(4);

                            taskId = reader.IsDBNull(5) ? taskId = 0
                              : taskId = reader.GetInt32(5);
                            taskName = reader.IsDBNull(6) ? taskName = null
                                : taskName = reader.GetString(6);
                            taskDescription = reader.IsDBNull(7) ? taskDescription = null
                                : taskDescription = reader.GetString(7);
                            taskFreeApi = reader.IsDBNull(8) ? taskFreeApi = null
                                : taskFreeApi = reader.GetString(8);
                            taskPeriodcityTask = reader.IsDBNull(9) ? taskPeriodcityTask = 0
                                : taskPeriodcityTask = reader.GetInt32(9);
                            taskMomentTaskStarts = reader.IsDBNull(10) ? taskMomentTaskStarts = null
                                : taskMomentTaskStarts = reader.GetString(10);
                            taskDataOfTask = reader.IsDBNull(11) ? taskDataOfTask = null
                                : taskDataOfTask = reader.GetString(11);
                            taskAppSettings = reader.IsDBNull(12) ? taskAppSettings = null
                                : taskAppSettings = reader.GetString(12);
                            taskLastDateTime = reader.IsDBNull(13) ? taskLastDateTime = null
                                : taskLastDateTime = reader.GetString(13);
                            roleId = reader.IsDBNull(14) ? roleId = 0
                                : reader.GetInt32(14);
                            roleName = reader.IsDBNull(15) ? roleName = null
                                : roleName = reader.GetString(15);

                            var user = users.Where(p => p.Id == userId).FirstOrDefault();
                            if (user == null)
                            {
                                user = new UserDL();
                                user.Id = userId;
                                user.Name = userName;
                                user.LastName = usesLastName;
                                user.Email = userEmail;
                                user.Password = userPassword;
                                user.Role = new RoleDL
                                {
                                    Id = roleId,
                                    Name = roleName
                                };

                                var task = new TaskInfoDAL()
                                {
                                    Id = taskId,
                                    Name = taskName,
                                    Description = taskDescription,
                                    FreeApi = taskFreeApi,
                                    PeriodicityTask = taskPeriodcityTask,
                                    AppSettings = taskAppSettings,
                                    DataOfTask = taskDataOfTask,
                                    LastDateTime = taskLastDateTime,
                                    MomentTaskStarts = taskMomentTaskStarts,
                                };

                                user.TaskInfo = new List<TaskInfoDAL>();
                                user.TaskInfo.Add(task);
                                users.Add(user);
                            }
                            else
                            {
                                var task = new TaskInfoDAL()
                                {
                                    Id = taskId,
                                    Name = taskName,
                                    Description = taskDescription,
                                    FreeApi = taskFreeApi,
                                    PeriodicityTask = taskPeriodcityTask,
                                    AppSettings = taskAppSettings,
                                    DataOfTask = taskDataOfTask,
                                    LastDateTime = taskLastDateTime,
                                    MomentTaskStarts = taskMomentTaskStarts,
                                };

                                if (!user.TaskInfo.Contains(task))
                                    user.TaskInfo.Add(task);
                            }
                        }
                    }
                    return users.FirstOrDefault();
                }
            }
        }
    }
}


