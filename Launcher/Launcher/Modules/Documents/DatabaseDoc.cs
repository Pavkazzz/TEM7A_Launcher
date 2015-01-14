using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Net.Mime;

namespace Launcher.Modules.Documents
{
    internal static class DatabaseDoc
    {
        

        private static SQLiteConnection _sqLiteConnectionDatabase;

        private static void ConnectToDB(string path)
        {
            _sqLiteConnectionDatabase =
                new SQLiteConnection(string.Format(@"Data Source={0}\Normative documents.db", path));
            _sqLiteConnectionDatabase.Open();
        }

        private static void CloseConnectionSqlite()
        {
            _sqLiteConnectionDatabase.Close();
        }

        public static List<Helper.Category> CategoryList()
        {
            ConnectToDB(App.ResourcePath);
            var result = new List<Helper.Category>();
            var sqlCommand = new SQLiteCommand(string.Format("Select Name, TableName from CategoryDocuments"), _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
            foreach (DbDataRecord record in sqlReader)
            {
                result.Add( new Helper.Category(record["Name"].ToString(), record["TableName"].ToString()));
            }
            sqlReader.Close();
            CloseConnectionSqlite();
            return result;
        }

        public static List<string> GetCategory(string category)
        {
            ConnectToDB(App.ResourcePath);
            var result = new List<string>();
            var sqlCommand = new SQLiteCommand(string.Format("Select Name, Path from {0}", category), _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
            foreach (DbDataRecord record in sqlReader)
            {
                result.Add(record["Name"].ToString());
            }
            sqlReader.Close();
            CloseConnectionSqlite();
            return result;
        }

        public static void AddToHistory(string name)
        {
            ConnectToDB(App.ResourcePath);
            //Все numb +1
            var sqLiteCommand = new SQLiteCommand("UPDATE History SET numb = numb + 1", _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqLiteCommand.ExecuteReader();
            sqlReader.Close();

            if (CheckHistory(name))
            {
                sqLiteCommand = new SQLiteCommand(
                    string.Format("Update History set numb = 1 where Name = '{0}'", name), _sqLiteConnectionDatabase);  
            }
            else
            {
                sqLiteCommand = new SQLiteCommand(string.Format("Insert into History values('{0}', 1, 0)", name),
                    _sqLiteConnectionDatabase);   
            }
            sqlReader = sqLiteCommand.ExecuteReader();
            sqlReader.Close();
            CloseConnectionSqlite();
        }

        private static bool CheckHistory(string name)
        {
            ConnectToDB(App.ResourcePath);
            var sqlCommand = new SQLiteCommand(string.Format("Select Name from History where Name = '{0}'", name),
                _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
            var result = sqlReader.HasRows;
            sqlReader.Close();
            CloseConnectionSqlite();
            return result;
        }

        public static List<Book> GetHistory()
        {
            ConnectToDB(App.ResourcePath);
            var result = new List<Book>();
            var sqlCommand = new SQLiteCommand("select Name, Page from History order by Numb limit 9",
                _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
            foreach (DbDataRecord record in sqlReader)
            {
                result.Add(new Book(record["Name"].ToString(), (int) record["Page"]));
            }
            sqlReader.Close();
            CloseConnectionSqlite();
            return result;
        }

        public static void UpdatePage(string name, int page)
        {
            ConnectToDB(App.ResourcePath);
            var sqLiteCommand =
                new SQLiteCommand(string.Format("Update History set page = {0} where Name = '{1}'", page, name),
                    _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqLiteCommand.ExecuteReader();
            sqlReader.Close();
            CloseConnectionSqlite();
        }


        public static List<string> Search(string searchstring)
        {
            

            var result = new List<string>();

            List<string> tables = GetTables(App.ResourcePath, new List<string>{"History", "CategoryDocuments"});


            ConnectToDB(App.ResourcePath);
            SQLiteDataReader sqlReader = null;
            foreach (var table in tables)
            {
                SQLiteCommand sqLiteCommand =
                new SQLiteCommand(string.Format("Select Name from {0} where Name LIKE '%{1}%'", table, searchstring),
                    _sqLiteConnectionDatabase);
                sqlReader = sqLiteCommand.ExecuteReader();
                foreach (DbDataRecord record in sqlReader)
                {
                    result.Add(record["Name"].ToString());
                }
            }
            if (sqlReader != null && !sqlReader.IsClosed) sqlReader.Close();
            CloseConnectionSqlite();

            return result;
        }

        private static List<string> GetTables(string path, List<string> excludeTable)
        {
            ConnectToDB(path);
            List<string> result = new List<string>();
            var sqlCommand = new SQLiteCommand("select name from sqlite_master where type = 'table'",
                _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
            foreach (DbDataRecord record in sqlReader)
            {
                if (!excludeTable.Contains(record["name"].ToString()))
                {
                    result.Add(record["name"].ToString());
                }
            }
            sqlReader.Close();
            CloseConnectionSqlite();
            return result;

        }
    }
}