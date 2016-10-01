using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Core
{
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
