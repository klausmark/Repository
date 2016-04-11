using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Reflection;

namespace Repository
{
    public class SQLiteRepository<T> : IRepository<T, int> where T : IValueItem<int>
    {
        public SQLiteRepository()
        {
            var typeOfT = typeof (T);
            var tableName = typeOfT.Name;
            var properties = typeOfT.GetProperties(BindingFlags.SetProperty | BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
            var sql = $"CREATE TABLE IF NOT EXISTS '{tableName}'('Id' INTEGER PRIMARY KEY ASC";
            foreach (var propertyInfo in properties)
                if (propertyInfo.Name.ToLower() != "id") sql += $", '{propertyInfo.Name}'";
            sql += ");";

            using (var sqLiteConnection = new SQLiteConnection(@"Data Source=mydb.db;Version=3;"))
            {
                sqLiteConnection.Open();
                var command = new SQLiteCommand(sql, sqLiteConnection);
                command.ExecuteNonQuery();
                command.CommandText = $"SELECT * FROM {tableName};";
                var bla = command.ExecuteReader();

                foreach (var a in bla)
                {
                    var noget = a;
                } 
            }
        }
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}