using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Launcher.Core
{
    public class User
    {
        public User(string login, string password, string name, string lastname, string email, string patronymic)
        {
            LoginName = login;
            Password = password;
            Name = name;
            Lastname = lastname;
            Email = email;
            Patronymic = patronymic;
        }

        public User()
        {
            Patronymic = string.Empty;
            LoginName = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            Lastname = string.Empty;
            Email = string.Empty;
            Remember = false;
        }

        public string LoginName { get;  set; }
        public string Password { get;  set; }
        public string Name { get;  set; }
        public string Lastname { get;  set; }
        public string Patronymic { get;  set; }
        public string Email { get;  set; }
        public bool Remember { get; set; }

        public bool Login(String login, String pass, bool remember)
        {
            if (login != null && pass != null && login != string.Empty && pass != string.Empty && remember != null)
            {
                Remember = remember;
                var db = new DataBase();
                var result = false;
                var hashPass = Security.GetSHA512(pass);
                var select = db.SqlSelect(
                    string.Format("Select Name, Lastname from Accounts where Login = '{0}' and Password = '{1}'", login,
                        hashPass), new List<string> { "Name", "Lastname" });

                result = select.Count > 0;
                return result;
            }
            return false;
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