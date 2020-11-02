using System;
using System.IO;
using SQLite;
using UserBase.Entities;

namespace UserBase.DataAccess
{
    public static class DatabaseManager
    {
        static SQLiteAsyncConnection _database;

        public static SQLiteAsyncConnection Database
        {
            get
            {
                if (_database == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "userbase.db3");
                    _database = new SQLiteAsyncConnection(dbPath);
                    _database.CreateTableAsync<User>().Wait();
                }
                return _database;
            }
        }
    }
}
