using System;
using System.Diagnostics;
using System.Windows.Controls;

namespace Launcher.Views
{
    /// <summary>
    ///     Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            Process.Start(path + "\\osk.exe");
        }
    }
}