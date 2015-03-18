using System;
using System.Diagnostics;
using System.Net.PeerToPeer.Collaboration;
using System.Windows.Controls;
using System.Windows.Automation;

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
           // System.Windows.Automation.Peers.AutomationEvents.
            string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
            Process.Start(path + "\\osk.exe");
        }
    }
}