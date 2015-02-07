using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Launcher.Core
{
    public class User
    {
        public User(string login, string password, string name, string lastname, string email)
        {
            LoginName = login;
            Password = password;
            Name = name;
            Lastname = lastname;
            Email = email;
        }

        public User()
        {
            LoginName = String.Empty;
            Password = String.Empty;
            Name = String.Empty;
            Lastname = String.Empty;
            Email = String.Empty;
        }

        public string LoginName { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Lastname { get; private set; }
        public string Email { get; private set; }

        public bool Login(String login, String pass)
        {
            var db = new DataBase();
            var result = false;
            var hashPass = Security.GetSHA512(pass);
            var select = db.SqlSelect(
                string.Format("Select Name, Lastname from Accounts where Login = '{0}' and Password = '{1}'", login,
                    hashPass), new List<string> {"Name", "Lastname"});

            result = select.Count > 0;
            return result;
        }

        public void Registration(User user)
        {
            var hashPass = Security.GetSHA512(user.Password);
            try
            {
                //OpenConnectionSqlite(App.ResourcePath);
                //var sqlSelect = new SQLiteCommand(string.Format("Insert Into Accounts Values ('{0}', '{1}', '{2}', '{3}', '{4}')", user.Login,
                //    hashPass, user.Name, user.Lastname, user.Email), _sqLiteConnectionDatabase);
                //SQLiteDataReader sqlReader = sqlSelect.ExecuteReader();
                //sqlReader.Close();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
            }
        }
    }
}