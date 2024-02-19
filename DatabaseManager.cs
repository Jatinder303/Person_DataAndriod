using Person_DataAndriod.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_DataAndriod
{
    public class DatabaseManager
    {
        readonly SQLiteConnection connection;

        public DatabaseManager()
        {
            string directoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            if (Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string dbPath = Path.Combine(directoryPath, "Person_Data.db");

            connection = new SQLiteConnection(dbPath);

            connection.CreateTable<SignUp>();
        }

        public void InsertUser(SignUp new_user)
        {
            connection.Insert(new_user);
        }

        public List<SignUp> GetUsers()
        {
            return connection.Table<SignUp>().ToList();
        }
    }
}
