using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicApplication.Helpers
{
    public static class SQLiteHelper
    {
        private static string dbFile = Path.Combine(Environment.CurrentDirectory, "DB.db3");

        public static int Delete<T>(T value)
        {
            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                return conn.Delete(value);
            }
        }

        public static List<T> Read<T>() where T : new()
        {
            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                return conn.Table<T>().ToList<T>();
            }
        }

        public static int Update<T>(T value)
        {
            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                return conn.Update(value);
            }
        }

        public static int Insert<T>(T value)
        {
            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                return conn.Insert(value);
            }
        }
    }
}
