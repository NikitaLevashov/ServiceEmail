using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;

namespace ServiceEmail.DAL.DataBase
{
    public class SeedData
    {
        public IConfiguration AppConfiguration { get; set; }
        public void SeedDatabase()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            AppConfiguration = builder.Build();

            using (var connection = new SqliteConnection(AppConfiguration["Data:UserDataBase:ConnectionStrings"]))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.Parameters.AddWithValue("@email_1", "admin@mail.com");
                command.Parameters.AddWithValue("@password_1", "1111");
                command.Parameters.AddWithValue("@email_2", "asdq@mail.com2");
                command.Parameters.AddWithValue("@password_2", "1111");
                command.Parameters.AddWithValue("@email_3", "emailservicetest@mail.ru");
                command.Parameters.AddWithValue("@password_3", "ivanov123456");

                command.CommandText = @"PRAGMA foreign_keys = on;CREATE TABLE IF NOT EXISTS Roles(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL);
                    INSERT INTO Roles(Name) VALUES('user'); INSERT INTO Roles(Name) VALUES('admin');
                    CREATE TABLE IF NOT EXISTS Users(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,Name TEXT NOT NULL, LastName TEXT NOT NULL, Email TEXT NOT NULL
                    UNIQUE, Password TEXT NOT NULL, RoleId INTEGER, FOREIGN KEY(RoleId) REFERENCES Roles(Id));CREATE TABLE IF NOT EXISTS TasksInfo(Id INTEGER PRIMARY KEY
                    AUTOINCREMENT UNIQUE, Name TEXT, Description TEXT, LastDateTime TEXT,PeriodicityTask INTEGER, MomentTaskStarts TEXT, FreeApi TEXT, AppSettings TEXT, 
                    DataOfTask, UserID INTEGER, FOREIGN KEY(UserId) REFERENCES Users(Id));INSERT INTO Users(Name, LastName, Email, Password, RoleId) VALUES('Admin', 'Admin',
                    @email_1, @password_1,'2');INSERT INTO Users(Name, LastName, Email, Password, RoleId) VALUES('Alecsandr', 'Mironov', @email_2, @password_2, 1);
                    INSERT INTO Users(Name, LastName, Email, Password, RoleId) VALUES('Nikita', 'Levashov', @email_3, @password_3, 1);";
                command.ExecuteNonQuery();

                Console.WriteLine("Таблица Users создана");
            }
        }
    }
}
