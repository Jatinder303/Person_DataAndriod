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

        public DatabaseManager(string dbPath)
        {
            connection = new SQLiteConnection(dbPath);
            connection.CreateTable<SignUp>();
        }

        public void InsertUser(SignUp new_user)
        {
            connection.Insert(new_user);
        }
    }
}
