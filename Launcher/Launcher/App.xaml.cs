using System.IO;
using System.Windows;

namespace Launcher
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly string ResourcePath = Path.GetFullPath(@"../../Resources");
        public static readonly string ModulesPath = Path.GetFullPath(@"../../Modules");
        public static readonly string DocPath = Path.GetFullPath(@"../../Documents/GOST");
    }
}