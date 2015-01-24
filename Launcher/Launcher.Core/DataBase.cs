using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows;
using Launcher.Core;

namespace Launcher.Core
{
    public class DataBase
    {
        private SQLiteConnection _sqLiteConnectionDatabase;
/*
        private SQLiteDataAdapter _sqLiteDataAdapter;
*/

        private void OpenConnectionSqlite(string path)
        {
            _sqLiteConnectionDatabase = new SQLiteConnection(string.Format(@"Data Source={0}\db.db", path));
            _sqLiteConnectionDatabase.Open();
        }

        private void CloseConnectionSqlite()
        {
            _sqLiteConnectionDatabase.Close();
        }

        public List<Dictionary<string, string>> SqlSelect(string sqlQuery, List<string> columnName, string path = "...resource...")
        {
            OpenConnectionSqlite(System.IO.Path.GetFullPath(@"../../../Launcher.Core/Db"));
            var result = new List<Dictionary<string, string>>();
            var sqlSelect = new SQLiteCommand(sqlQuery, _sqLiteConnectionDatabase);
            SQLiteDataReader sqlReader = sqlSelect.ExecuteReader();
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

        //TODO REFACTOR TO VIEW LAUNCHER
        //public List<ListBoxItemModuleControl> SelectModulesList(string path)
        //{
        //    var result = new List<ListBoxItemModuleControl>();
        //    try
        //    {
        //        OpenConnectionSqlite(App.ResourcePath);
        //        var sqlSelect = new SQLiteCommand("Select Title, Description from Modules", _sqLiteConnectionDatabase);
        //        SQLiteDataReader sqlReader = sqlSelect.ExecuteReader();
        //        foreach (DbDataRecord record in sqlReader)
        //        {
        //            var menuItemControl = new ListBoxItemModuleControl();
        //            menuItemControl.TextBlockTitle.Text = record["Title"].ToString().ToUpper();
        //            menuItemControl.TextBlockDescription.Text = record["Description"].ToString();
        //            result.Add(menuItemControl);  
        //        }
        //        sqlReader.Close();
        //        CloseConnectionSqlite();
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.ToString());
        //    }
        //    return result;
        //}




    }
}
