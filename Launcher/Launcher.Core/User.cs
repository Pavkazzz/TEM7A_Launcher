using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Launcher.Core
{
    public class User : IUser
    {
        public User(string login, string password, string name, string lastname, string email, string patronymic)
        {
            PersonalNumber = login;
            Password = password;
            Name = name;
            Lastname = lastname;
            Email = email;
            Patronymic = patronymic;
        }

        public User()
        {
            Patronymic = string.Empty;
            PersonalNumber = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            Lastname = string.Empty;
            Email = string.Empty;
            Remember = false;
        }
        public string PersonalNumber { get; set; }
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
                var hashPass = Security.GetSHA512(pass);
                var select = db.SqlSelect(
                    string.Format("Select Name, Lastname from Accounts where PersonalNumber = '{0}' and Password = '{1}'", login,
                        hashPass), new List<string> { "Name", "Lastname" });

                var result = select.Count > 0;
                return result;
            }
            return false;
        }

        public void Registration(IUser user)
        {
            var db = new DataBase();
            
            var hashPass = Security.GetSHA512(user.Password);
            db.SqlInsert(string.Format("Insert Into Accounts Values ('{0}', '{1}', '{2}', '{3}', '{4}')", user.PersonalNumber, hashPass, user.Name, user.Lastname, user.Patronymic));
        }
    }

    public interface IUser
    {
        string PersonalNumber { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        string Lastname { get; set; }
        string Patronymic { get; set; }
        string Email { get; set; }
        bool Remember { get; set; }

        bool Login(string login, string pass, bool remember);

        void Registration(IUser user);
    }
}