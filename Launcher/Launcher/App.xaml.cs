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
