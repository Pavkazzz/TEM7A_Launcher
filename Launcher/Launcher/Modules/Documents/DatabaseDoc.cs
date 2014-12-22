using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Launcher.Modules.Documents
{
    static class DatabaseDoc
    {
        static private SQLiteConnection _sqLiteConnectionDatabase;
        
        static private void ConnectToDB(string path)
        {   
            _sqLiteConnectionDatabase = new SQLiteConnection(string.Format(@"Data Source={0}\Normative documents.db",path));
            _sqLiteConnectionDatabase.Open();
        }

        static private void CloseConnectionSqlite()
        {
            _sqLiteConnectionDatabase.Close();
        }

        static public List<string> ReturnGost()
        {
            ConnectToDB(App.ResourcePath);
            var result = new List<string>();
            SQLiteCommand sqlCommand = new SQLiteCommand("Select Name, Path from Gost", _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    result.Add(sqlReader["Name"].ToString());  
                }
            }
            sqlReader.Close();
            CloseConnectionSqlite();
            return result;
        }

        public static void AddToHistory(string name)
        {
            ConnectToDB(App.ResourcePath);
            //Все numb +1
            SQLiteCommand sqLiteCommand = new SQLiteCommand("UPDATE History SET numb = numb + 1", _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqLiteCommand.ExecuteReader();
            sqlReader.Close();

            if (CheckHistory(name))
            {
                sqLiteCommand = new SQLiteCommand(string.Format("Update History set numb = 1 where Name = '{0}'", name), _sqLiteConnectionDatabase);
                sqlReader = sqLiteCommand.ExecuteReader();
                sqlReader.Close();
            }
            else
            {

                sqLiteCommand = new SQLiteCommand(string.Format("Insert into History values('{0}', 1, 0)", name), _sqLiteConnectionDatabase);
                sqlReader = sqLiteCommand.ExecuteReader();
                sqlReader.Close();
            }

            CloseConnectionSqlite();
        }

        private static bool CheckHistory(string name)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(string.Format("Select Name from History where Name = '{0}'", name), _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
            return sqlReader.HasRows;
        }

        public static List<Book> GetHistory()
        {
            ConnectToDB(App.ResourcePath);
            var result = new List<Book>();
            SQLiteCommand sqlCommand = new SQLiteCommand("select Name, Page from History order by Numb limit 9", _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    result.Add(new Book(sqlReader["Name"].ToString(), (int)sqlReader["Page"]));  
                }
            }
            sqlReader.Close();
            CloseConnectionSqlite();
            return result;
            
        }

        public static void UpdatePage(string name, int page)
        {
            ConnectToDB(App.ResourcePath);
            var sqLiteCommand = new SQLiteCommand(string.Format("Update History set page = {0} where Name = '{1}'", page, name), _sqLiteConnectionDatabase);
            var sqlReader = sqLiteCommand.ExecuteReader();
            sqlReader.Close();
            CloseConnectionSqlite();
        }
    }
}
