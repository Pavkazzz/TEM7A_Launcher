using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly string ResourcePath = System.IO.Path.GetFullPath(@"../../Resources");
        public static readonly string ModulesPath = System.IO.Path.GetFullPath(@"../../Modules");
        public static readonly string DocPath = System.IO.Path.GetFullPath(@"../../Documents/GOST");

    }
}
