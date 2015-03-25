using System;
using System.Diagnostics;
using System.Net.PeerToPeer.Collaboration;
using System.Windows.Controls;
using System.Windows.Automation;
using System.Windows.Input;

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
            
        }

        private void PersonalNumber_OnMouseEnter(object sender, MouseEventArgs e)
        {
            //KeyboardProperty.KeyboardClose();
        }

        private void Password_SelectionChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            KeyboardProperty.KeyboardRun();
        }
    }
}