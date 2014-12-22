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
    class DatabaseDoc
    {
        private SQLiteConnection _sqLiteConnectionDatabase;
        
        private void ConnectToDB(string path)
        {   
            _sqLiteConnectionDatabase = new SQLiteConnection(string.Format(@"Data Source={0}\Normative documents.db",path));
            _sqLiteConnectionDatabase.Open();
        }

        private void CloseConnectionSqlite()
        {
            _sqLiteConnectionDatabase.Close();
        }

        public List<string> ReturnGost()
        {
            ConnectToDB(App.ResourcePath);
            var result = new List<string>();
            SQLiteCommand sqlCommand = new SQLiteCommand("Select NAME_GOST,Source_To_Document from GOST_TABLE", _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqlCommand.ExecuteReader();
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    result.Add(sqlReader["NAME_GOST"].ToString());  
                }
            }
            CloseConnectionSqlite();
            return result;
        }

        internal void SelectGost()
        {
            ConnectToDB(App.ResourcePath);

            SQLiteCommand sqLiteCommand = new SQLiteCommand("Insert into ");

            CloseConnectionSqlite();
        }
    }
}
