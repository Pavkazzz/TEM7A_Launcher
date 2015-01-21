using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Core
{
    class User
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Lastname { get; private set; }
        public string Email { get; private set; }

        public User(string login, string password, string name, string lastname, string email)
        {
            Login = login;
            Password = password;
            Name = name;
            Lastname = lastname;
            Email = email;
        }
    }
}
