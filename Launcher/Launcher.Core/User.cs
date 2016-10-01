using System;
using System.Collections.Generic;
using System.Windows.Annotations;

namespace Launcher.Core
{
    public class User : IUser
    {

        public string PersonalNumber { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public bool Remember { get; set; }


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

        public bool Login(String personalNumber, String pass, bool remember)
        {
            if (personalNumber != null && pass != null && personalNumber != string.Empty && pass != string.Empty && remember != null)
            {
                Remember = remember;
                var db = new DataBase();
                var hashPass = Security.GetSHA512(pass);
                var select = db.SqlSelect(
                    string.Format("Select Name, Lastname from Accounts where PersonalNumber = '{0}' and Password = '{1}'", personalNumber,
                        hashPass), new List<string> { "Name", "Lastname" });

                var result = select.Count > 0;
                return result;
            }
            return false;
        }

        public void Registration(IUser user)
        {
            if (user.Password != string.Empty && user.PersonalNumber != string.Empty)
            {
                var db = new DataBase();

                var hashPass = Security.GetSHA512(user.Password);
                db.SqlInsert(string.Format("Insert Into Accounts Values ('{0}', '{1}', '{2}', '{3}', '{4}')", user.PersonalNumber, hashPass, user.Name, user.Lastname, user.Patronymic));
            }
           
        }
    }

}