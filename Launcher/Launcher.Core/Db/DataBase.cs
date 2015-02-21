using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace Launcher.Core
{
    public class DataBase
    {
        private SQLiteConnection _sqLiteConnectionDatabase;

        private readonly string _connectionPath;

        //private SQLiteDataAdapter _sqLiteDataAdapter;


        public DataBase()
        {
            _connectionPath = Path.GetFullPath(@"..\..\..\..\Launcher.Core\Db\db.db");
        }

        public DataBase(string path)
        {
            _connectionPath = path;
        }

        private void OpenConnectionSqlite(string path)
        {
            _sqLiteConnectionDatabase = new SQLiteConnection(string.Format(@"Data Source={0}", path));
            _sqLiteConnectionDatabase.Open();
        }

        private void CloseConnectionSqlite()
        {
            _sqLiteConnectionDatabase.Close();
        }

        //TODO path
        public List<Dictionary<string, string>> SqlSelect(string sqlQuery, List<string> columnName)
        {
            OpenConnectionSqlite(_connectionPath);
            var result = new List<Dictionary<string, string>>();
            var sqlSelect = new SQLiteCommand(sqlQuery, _sqLiteConnectionDatabase);
            var sqlReader = sqlSelect.ExecuteReader();
            try
            {
                foreach (DbDataRecord record in sqlReader)
                {
                    var temp = new Dictionary<string, string>();
                    foreach (var column in columnName)
                    {
                        temp.Add(column, record[column].ToString());
                    }   
                    result.Add(temp);
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine("Select upal " + e.Message);
            }

            sqlReader.Close();
            CloseConnectionSqlite();
            return result;
        }

        public bool SqlInsert(string sqlQuery)
        {
            try
            {
                OpenConnectionSqlite(_connectionPath);
                var sqlSelect = new SQLiteCommand(sqlQuery, _sqLiteConnectionDatabase);
                var sqlReader = sqlSelect.ExecuteReader();
                sqlReader.Close();
                CloseConnectionSqlite();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        } 
    }
}