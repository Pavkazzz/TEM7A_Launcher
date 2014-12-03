using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows;

namespace Launcher
{
    class DataBase
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

        public bool Login(String login, String pass)
        {
            bool result = false;
            try
            {
                OpenConnectionSqlite(App.ResourcePath);
                var sqlSelect = new SQLiteCommand(string.Format("Select Name, Lastname from Accounts where Login = '{0}' and Password = '{1}'", login, pass),
                    _sqLiteConnectionDatabase);
                SQLiteDataReader sqlReader = sqlSelect.ExecuteReader();
                result = sqlReader.HasRows;
                sqlReader.Close();
                CloseConnectionSqlite();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            
            return result;
        }

        public List<MenuItemControl> SelectModulesList(string path)
        {
            var result = new List<MenuItemControl>();
            try
            {
                OpenConnectionSqlite(App.ResourcePath);
                var sqlSelect = new SQLiteCommand("Select Title, Description from Modules", _sqLiteConnectionDatabase);
                SQLiteDataReader sqlReader = sqlSelect.ExecuteReader();
                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        var menuItemControl = new MenuItemControl();
                        menuItemControl.TextBlockTitle.Text = sqlReader["Title"].ToString().ToUpper();
                        menuItemControl.TextBlockDescription.Text = sqlReader["Description"].ToString();
                        result.Add(menuItemControl);
                    }
                }

                sqlReader.Close();
                CloseConnectionSqlite();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            return result;
        }


        public void Registration(User user)
        {
            try
            {
                OpenConnectionSqlite(App.ResourcePath);
                var sqlSelect = new SQLiteCommand(string.Format("Insert Into Accounts Values ('{0}', '{1}', '{2}', '{3}', '{4}')", user.Login,
                    user.Password, user.Name, user.Lastname, user.Email), _sqLiteConnectionDatabase);
                SQLiteDataReader sqlReader = sqlSelect.ExecuteReader();
                sqlReader.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}
