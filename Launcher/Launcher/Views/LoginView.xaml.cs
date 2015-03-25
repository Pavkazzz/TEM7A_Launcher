using System;
using System.Diagnostics;
using System.Net.PeerToPeer.Collaboration;
using System.Windows;
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


        private void Password_SelectionChanged(object sender, RoutedEventArgs e)
        {
            KeyboardProperty.KeyboardRun();
        }

    }
}