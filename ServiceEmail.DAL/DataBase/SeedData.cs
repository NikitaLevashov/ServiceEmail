using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.DAL.DataBase
{
    public class SeedData
    {
        public static void SeedDatabase()
        {
            using (var connection = new SqliteConnection("Data Source=users.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = @"PRAGMA foreign_keys = on;CREATE TABLE IF NOT EXISTS Roles(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL);
                    INSERT INTO Roles(Name) VALUES('user'); INSERT INTO Roles(Name) VALUES('admin');
                    CREATE TABLE IF NOT EXISTS Users(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,Name TEXT NOT NULL, LastName TEXT NOT NULL, Email TEXT NOT NULL
                    UNIQUE, Password TEXT NOT NULL, RoleId INTEGER, FOREIGN KEY(RoleId) REFERENCES Roles(Id));CREATE TABLE IF NOT EXISTS TasksInfo(Id INTEGER PRIMARY KEY
                    AUTOINCREMENT UNIQUE, Name TEXT, Description TEXT, LastDateTime TEXT,PeriodicityTask INTEGER, MomentTaskStarts TEXT, FreeApi TEXT, AppSettings TEXT, 
                    DataOfTask, UserID INTEGER, FOREIGN KEY(UserId) REFERENCES Users(Id));INSERT INTO Users(Name, LastName, Email, Password, RoleId) VALUES('Admin', 'Admin',
                    'admin@mail.com', '1111','2');INSERT INTO Users(Name, LastName, Email, Password, RoleId) VALUES('Alecsandr', 'Mironov', 'asdq@mail.com2', '1111', 1);
                    INSERT INTO Users(Name, LastName, Email, Password, RoleId) VALUES('Nikita', 'Levashov', 'emailservicetest@mail.ru', 'ivanov123456', 1);";
                command.ExecuteNonQuery();

                Console.WriteLine("Таблица Users создана");
            }
        }
    }
}
