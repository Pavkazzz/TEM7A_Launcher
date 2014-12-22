using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static void SelectGost(string name)
        {
            ConnectToDB(App.ResourcePath);
            SQLiteCommand sqLiteCommand = new SQLiteCommand(string.Format("Insert into History values('{0}')", name), _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqLiteCommand.ExecuteReader();
            sqlReader.Close();
            CloseConnectionSqlite();
        }

        public static List<string> GetHistory()
        {
            ConnectToDB(App.ResourcePath);
            var result = new List<string>();
            SQLiteCommand sqlCommand = new SQLiteCommand("select Name from History order by rowid desc limit 9", _sqLiteConnectionDatabase);
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
    }
}
