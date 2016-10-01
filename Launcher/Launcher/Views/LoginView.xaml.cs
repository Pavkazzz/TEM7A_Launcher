using System.Windows;
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
            
        }


        private void Password_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //KeyboardProperty.KeyboardRun();
        }

    }
}