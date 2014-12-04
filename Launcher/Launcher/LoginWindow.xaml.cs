using System.Windows;
using MahApps.Metro.Controls;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {
        private readonly DataBase _dataBase = new DataBase();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Accept_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Passwb1.Password == Passwb2.Password)
            {
                var user = new User(Login_tbx.Text, Passwb1.Password, Name_tbx.Text, Family_tbx.Text, email_tbx.Text);
                _dataBase.Registration(user);   
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_dataBase.Login(EntryLogin.Text, EntryPassword.Password))
            {
                new MainWindowLauncher().ShowDialog();
            }
            else
            {
                MessageBox.Show("Запись не найдена");
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://pkbzht.ru");
        }
    }
}
